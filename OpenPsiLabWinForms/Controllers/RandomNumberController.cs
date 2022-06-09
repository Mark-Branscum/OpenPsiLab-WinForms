using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenPsiLabWinForms.Models;
using OpenPsiLabWinForms.Properties;

namespace OpenPsiLabWinForms.Controllers
{
    public class RandomNumberController
    {
        public enum RandomSourceTypes
        {
            Pseudo,
            TrueRNG,
            RandomOrg,
            None
        }
        private RandomSourceTypes randomSource
        {
            get
            {
                string randomSourceSetting = oplConfig.RandomnessSource.ToLower();
                switch (randomSourceSetting)
                {
                    case "pseudo":
                        return RandomSourceTypes.Pseudo;
                    case "truerng":
                        return RandomSourceTypes.TrueRNG;
                    case "random.org":
                        return RandomSourceTypes.RandomOrg;
                    default: return RandomSourceTypes.Pseudo;
                }
            }
        }

        private OPLConfiguration oplConfig;

        private string serialPortName
        {
            get
            {
                return oplConfig.RNGSerialPortName;
            }
        }


        public RandomNumberController(OPLConfiguration oplConfiguration)
        {
            oplConfig = oplConfiguration;
        }

        public RandomNumberResult GetRandomNumberNormalized(RandomSourceTypes methodRandomSource = RandomSourceTypes.None)
        {
            RandomSourceTypes randSource;
            if (methodRandomSource != RandomSourceTypes.None)
            {
                randSource = methodRandomSource;
            }
            else
            {
                randSource = randomSource;
            }

            RandomNumberResult returnResult = new RandomNumberResult();
            try
            {
                switch (randSource)
                {
                    case RandomSourceTypes.Pseudo:
                        returnResult = GetRandomNumberNormalizedFromPseudo();
                        break;
                    case RandomSourceTypes.TrueRNG:
                        returnResult = GetRandomNumberNormalizedFromTrueRNG();
                        break;
                    case RandomSourceTypes.RandomOrg:
                        returnResult = GetRandomNumberNormalizedFromRandomOrg();
                        break;
                }
                return returnResult;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public RandomNumberResult GetRandomNumberNormalizedFromPseudo()
        {
            byte[] bytes = new byte[4];
            RandomNumberResult returnResult = new RandomNumberResult();
            returnResult.randomSource = RandomNumberResult.randomSources.Pseudo;
            Random randNum = new Random();
            randNum.NextBytes(bytes);
            returnResult.randomNumber = normalize4Bytes(bytes);
            return returnResult;
        }

        public RandomNumberResult GetRandomNumberNormalizedFromTrueRNG()
        {
            //Get bytes from hardware random number generator.
            //Since the TrueRNG runs on a virtual COM port
            //it can run at any baud requested
            RandomNumberResult returnResult = new RandomNumberResult();
            returnResult.randomSource = RandomNumberResult.randomSources.TrueRNG;
            SerialPort randy = null;
            try
            {
                Byte[] bytes = new byte[4];
                randy = new SerialPort(serialPortName, 9600);
                randy.DtrEnable = false;
                randy.DtrEnable = true;
                randy.ReadTimeout = 3000;
                randy.Open();
                for (int i = 0; i < 4; i++)
                {
                    bytes[i] = (byte)randy.ReadByte();
                }
                returnResult.randomNumber = normalize4Bytes(bytes);
            }
            catch (System.Exception)
            {
                MessageBox.Show("Unable to get random number from hardware random number generator.  " +
                                "Please check your COM port settings in the Tool menu. Using " +
                                "pseudo random numbers instead.", "Error",
                    MessageBoxButtons.OK);
                oplConfig.RandomnessSource = "Pseudo"; 
                return GetRandomNumberNormalizedFromPseudo();
            }
            finally
            {
                try
                {
                    if (randy != null)
                    {
                        randy.Close();
                    }
                }
                catch (System.Exception)
                {
                    //ignore
                }
            }
            return returnResult;
        }

        public RandomNumberResult GetRandomNumberNormalizedFromRandomOrg()
        {
            RandomNumberResult randomResult = new RandomNumberResult();
            randomResult.randomSource = RandomNumberResult.randomSources.RandomOrg;
            string responseStr = string.Empty;
            string url = "https://www.random.org/integers/?num=1&min=-1000000000&max=1000000000&col=1&base=10&format=plain&rnd=new";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            responseStr = GetWebResponseString(request: req);
            int num = int.Parse(responseStr);
            num += 1000000000;
            double normalized = num / 2000000000.00;
            randomResult.randomNumber = normalized;
            return randomResult;
        }

        private double normalize4Bytes(byte[] bytes)
        {
            uint tempD = BitConverter.ToUInt32(bytes, 0);
            double twoBytesToDouble = (double)tempD / (double)4294967295;
            return twoBytesToDouble;
        }

        private string GetWebResponseString(WebRequest request)
        {
            string responseMessage = string.Empty;
            string strReturn = string.Empty;
            HttpWebResponse response = null;
            string status = string.Empty;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                status = response.StatusDescription;

                if (status.ToUpper() == "CREATED" || status.ToUpper() == "OK")
                {
                    Stream responseStream = response.GetResponseStream();

                    if (responseStream != null && responseStream != Stream.Null)
                    /* ResponseStream != null checks for whether a reference
                    to a Stream has been assigned to the variable responseStream, whereas 
                    responseStream != Stream.Null checks whether or not the Stream instance assigned 
                    to responseStream contains any backing data.*/
                    {
                        StreamReader strmReader = new StreamReader(responseStream);
                        string apiResult = strmReader.ReadToEnd();
                        strReturn = apiResult;
                        strmReader.Close();
                        responseStream.Close();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (UriFormatException ex)
            {
                throw ex;
            }
            catch (IOException ex)
            {
                throw ex;
            }
            catch (WebException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
            return strReturn;
        }
    }
}
