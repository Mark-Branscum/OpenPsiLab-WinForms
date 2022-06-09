using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPsiLabWinForms.Models;

namespace OpenPsiLabWinForms.Interfaces
{
    public interface IDatabase
    {
        void Initialize();
        Guid ImageUpsert(ImageAsset imageAsset);
        List<ImageAsset> ImagesGet(List<Guid> uuids);
        List<Guid> ImageUUIDsGetAll();
        T ConvertFromDBVal<T>(object obj);
        void SessionPracticeSave(RVSession rvSession, bool overwrite);
        void SetImageActive(Guid uuid, bool active);
    }
}
