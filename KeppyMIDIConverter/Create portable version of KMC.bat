@echo off

rem License file lel
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z license.rtf
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\GMGeneric.sf2

rem These are the 32-bit files
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z "bin\x86\Restore language.bat"
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z "bin\x86\Skip update process.bat"
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\KeppyMIDIConverter.exe
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\KeppyMIDIConverter.exe.config
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\kmcogg.exe
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\kmcmp3.exe
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\bass.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\bass_mpc.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\bass_vst.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\bassenc.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\bassflac.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\bassmidi.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\bassopus.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\basswv.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x86\portable

rem These are the 64-bit ones
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z "bin\x64\Restore language.bat"
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z "bin\x64\Skip update process.bat"
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\KeppyMIDIConverter.exe
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\KeppyMIDIConverter.exe.config
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\kmcogg.exe
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\kmcmp3.exe
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\bass.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\bass_mpc.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\bass_vst.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\bassenc.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\bassflac.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\bassmidi.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\bassopus.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\basswv.dll
7za a -t7z -m0=lzma -mx=9 -mfb=64 -md=32m -ms=on bin\KeppyMIDIConverterPortable.7z bin\x64\portable