# Keppy's MIDI Converter
[![Join the chat at https://gitter.im/KaleidonKep99/Keppys-MIDI-Converter](https://badges.gitter.im/KaleidonKep99/Keppys-MIDI-Converter.svg)](https://gitter.im/KaleidonKep99/Keppys-MIDI-Converter?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
<br>
A fully functional MIDI to WAV converter, for FREE!

## Can I use your program's source code for my program?
Sure you can, but there are a few "rules" you need to follow.

What you can do:
- Take parts of the code, and use it on your apps. (As long as you credit me, BASS.NET and Un4seen.)
- Share the code on websites outside of the GitHub world. (Again, same as before.)
- Create ports of the converter for other operating systems, such as Linux, Mac OS X, Amiga etc... Any other O.S. other than Windows. (See down below for further explanations.)

What you can't do:
- Clone the source code of the converter, and change its name to "(Your name)'s MIDI Converter". I mean, why would you do that?
- Create ports of the converter in different programming languages, but with Windows support. There's already a Windows version, which is this one.
- Create phone ports of the converter. It is a PC-exclusive application.

If you break one of these rules... Well, "rip you".

## Where did you get the idea?
This was actually supposed to be a clone of [Free MIDI to MP3 Converter] (http://mp3-tools.com/free-midi-to-mp3-converter.html), then I changed myself, and had the idea of making my OWN converter, with my OWN stuff.

## Windows SmartScreen tells me that this app might infect my computer. Are you trying to steal my data???
Why would I publish KMC on GitHub, to get sued by them? I already have money issues irl, no needs to have more on the Internet.
Anyway no, the files are completely safe. The source code is online, even. Take a look if you don't trust my words.

## How can I get the converter without installing it?
There's a portable version of Keppy's MIDI Converter too. [Take a look here] (https://github.com/KaleidonKep99/Keppys-MIDI-Converter/releases).

## Is there any version for Linux and Mac OS X?
89Mods is working on it. It is based on Java, you can find it here: [https://github.com/89Mods/Keppy-s-MIDI-Converter-Multiplatform] (https://github.com/89Mods/Keppy-s-MIDI-Converter-Multiplatform)

## Requirements (Compiled program)
- Windows Vista SP1+ or newer.
- 256MB of RAM for normal conversions and playback, 1GB of RAM for the real-time simulator.
- DirectX 9 compliant sound card. (It DOES support old sound cards, but 32-bit float audio support is required for WAV playback)
- [Microsoft .NET Framework 4.5.] (https://www.microsoft.com/en-us/download/details.aspx?id=30653)

## Requirements (For compiling the program)
- Windows 7 SP1 or newer.
- 2GB of RAM or more.
- Microsoft Visual Studio 2013. (or newer, your choice)
- [BASS.NET] (http://www.bass.radio42.com/) by Radio42.

## Languages available:
Language | Available
------------ | -------------
Bengali | Yes
Chinese (Simplified) | Yes
Chinese (Traditional) | Yes
English | Yes
Estonian | Yes
German | Yes
Italian | Yes
Japanese | Yes
Korean | Yes
Russian | Yes
Spanish | Yes
Turkish | Yes

If your main language isn't here, and you're willing to help, just follow the guide down below.

## How can I contribute to the language support?
It's pretty easy and straightforward!<br>
Follow these easy steps:

1. Create a folder called "KMC translation" (Or whatever you want it to be called).
2. Download the base file ["Lang.resx"] (https://github.com/KaleidonKep99/Keppys-MIDI-Converter/blob/master/KeppyMIDIConverter/Languages/Lang.resx). Right-click "Raw" and select "Save as > .resx file". Remember to save it inside the folder you created on your desktop.
3. Download the language you want to update [from there] (https://github.com/KaleidonKep99/Keppys-MIDI-Converter/tree/master/KeppyMIDIConverter/Languages). As before, right-click "Raw" and select "Save as > .resx file". **(IT NEEDS TO BE IN THE SAME FOLDER AS LANG.RESX)**
4. *(If you don't have it)* Download and install ResEx [from there] (https://resex.codeplex.com/).
5. Open the "Lang.resx" file.
6. Happy editing! :smile:

When you're done, send the file **"Lang.(yourlanguagehere).resx"** to me through this form: https://goo.gl/forms/aHSvJescUqCYCHiN2<br><br>
Thank you in advance! :heart: :heart:

## Credits
- Thanks Ian Luck for his wonderful BASS libraries! Take a look to them here: [Un4seen website] (http://www.un4seen.com/)
- Thanks to Radio42 for his BASS.NET wrapper, that allows me to develop VB.NET/C# apps based off BASS libraries! Link: [BASS.NET] (http://www.bass.radio42.com/)
- Thanks to Jonathan from 365Icons, for the wonderful icon set used for the language selector! You can find the icon set here: [Click me] (http://365icon.com/icon-styles/ethnic/classic2/)
- Thanks to wyDay for VistaMenu, which I'm using to add icons to the default MainMenu control (MenuStrip is garbage). Download it here: [Click me] (https://wyday.com/vistamenu/)

## NuGet packages used
- Costura.Fody.1.3.3.0
- Resource.Embedder.1.2.0.0
- WindowsAPICodePack.1.1.0