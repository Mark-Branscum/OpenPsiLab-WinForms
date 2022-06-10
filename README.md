## Welcome to Open Psi Lab 


![Screenshot All](/Docs/ScreenshotAllLarge.png)
[[Enhance]](https://mark-branscum.github.io/OpenPsiLab-WinForms/Docs/ScreenshotAllLarge.png)

Open Psi Lab is free software for personal psi research and practice.  It is released under the open source [GPLv3 license.](https://www.gnu.org/licenses/gpl-3.0.en.html) Currently it provides utilities for remote viewing practice sessions, associative remote viewing sessions, sidereal time calculations and display of current geomagnetic weather.  This project is designed to run on Windows 7 or later.  Development is underway on versions that will run on MacOS, Linux (including Raspberry Pi) and WebAssembly, as well as mobile versions for Android and iOS.

### Installation

Before running Open Psi Lab you will need to have .NET Framework 4.8 or later and the WebView2 library from Microsoft installed on your machine.

If you are unsure which version of .NET you have, there are [several ways you can check.](https://www.windowscentral.com/how-quickly-check-net-framework-version-windows-10)  The .NET Framework 4.8 Runtime can be downloaded [directly](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-web-installer) or from Microsoft's [web page.](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48)

Microsoft WebView2 can be downloaded from their [web page.](https://developer.microsoft.com/en-us/microsoft-edge/webview2/)  We recommend using their Evergreen Bootstrapper.

![WebView2](/Docs/WebView2.png)

After prerequisties have been installed, download the latest version zip file of Open Psi Lab from this link:

[https://mark-branscum.github.io/OpenPsiLab-WinForms/LatestVersionRelease.zip](https://mark-branscum.github.io/OpenPsiLab-WinForms/LatestVersionRelease.zip) 

Once downloaded, unzip the zip file and launch the file named OpenPsiLabWinForms.exe.  Note, by default Windows doesn't show extensions like ".exe."  If that is the case on your machine, run the file that has the type "Application" not "Applicatin Manifest."

![File Extensions](/Docs/FileExtensions.png)

On first run you will be prompted to enter your longitude which is used for sidereal time calculations.  You can get your longitude by finding your location in Google maps, then right clicking.  Your longitude will be the number at the top right of the menu. Be sure to include the minus sign as shown if you live in the western hemisphere. This data is used exclusively by the software running on your machine and will not be otherwise collected or shared with anyone.  You can leave it blank in which case everything will still work except sidereal time calculations will not be accurate for your geographic location.

![Longitude](/Docs/Longitude.png)

Next you will need to add images to the program's image pool.  This is the pool of images that will be used whenever you ask the program to randomly select images for you.  You can load images into the pool by going to the menu item Tools -> Image Download

![Load Images](/Docs/ImageDownload.png)

### What's Next

Next I will be working on adding the following items:
- Remote viewing group sessions to manage multiple viewers viewing the same target
- Create target database to hold real world targets which can be randomly assigned to an RV session 
- Mark image pairs that are too similar / assign difficulty rating to image pairs
- Random Number Generator experiments
- Wizards to guide new RV users through typical RV session workflows step by step
- Session browser for quickly finding existing sessions
- Multiple image pools to group images for specific purposes
- Hardware for capture of galvanic skin response for presentiment experiments
- Mac and Linux/Raspberry Pi versions
- iOS and Android versions
- Cloud/server version for use by research teams to enforce participant adherence to specific experimental protocols
- Live video and EEG (electroencephalogram) data capture during remote viewing session
- Machine learning analysis of EEG data to identify times when the viewer is on target vs not

### Other Projects

Other projects under development:

![Open Sleep Lab Mask](/Docs/OpenSleepLabMask.jpeg)

- **Open Sleep Lab (Coming soon...)** - Open source hardware and software for sleep research including:
  - Network enabled sleep mask that can detect rapid eye movement, galvanic skin response, blood oxygen, pulse, etc.
   - Mask can be assembled by end users with readily available, off-the-shelf components that require no soldering and no other electronics or programming experience
  - Open source software to record sleep data and launch specific actions in response to data received from the mask such as playing an audio file or activating electrical relays, useful in lucid dreaming research 
  - Cloud networking system that allows multiple research subjects to be synced in real time to investigate phenomena such as synchronized dreaming or dream telepathy

### My Dream

I develop free and open source software and hardware for use in the investigation of psi, lucid dreaming and other phenomena.  My experiences with these phenomena have led me to view the world, myself, and others in a more connected, empathetic, and compassionate way.  I want to help others explore psi and provide opportunities for them to have their own meaningful experiences with it.  I want to ensure that tools to help them do so are available for free. 

If you would like to help me in this effort I would be humbly honored and deeply grateful.  If you choose to offer support or participation, I hope that I may always listen to your voice with humility, accept it with gratitude, and share with others these gifts you bring.

[My Patreon Page](https://www.patreon.com/MarkBranscum)

