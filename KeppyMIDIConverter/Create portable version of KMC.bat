@echo off

rem License file lel
7za a bin\KeppyMIDIConverterPortable.7z license.rtf -mx9 -m0=LZMA2 -t7z

rem These are the 32-bit files
7za a bin\KeppyMIDIConverterPortable.7z "bin\x86\Restore language.bat" -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z "bin\x86\Skip update process.bat" -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\KeppyMIDIConverter.exe -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\kmcogg.exe -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\bass.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\bassmidi.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\bass_vst.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\bassenc.dll -mx9 -m0=LZMA2 -t7z

rem These are the 64-bit ones
7za a bin\KeppyMIDIConverterPortable.7z "bin\x64\Restore language.bat" -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z "bin\x64\Skip update process.bat" -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\KeppyMIDIConverter.exe -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\kmcogg.exe -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\bass.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\bassmidi.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\bass_vst.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\bassenc.dll -mx9 -m0=LZMA2 -t7z

rem Languages x86
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\de\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\et\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\ko\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\es\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\en\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\it\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\ja\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\nl\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\zh-CN\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\zh-HK\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x86\zh-TW\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z

rem Languages x64
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\de\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\et\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\ko\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\es\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\en\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\it\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\ja\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\nl\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\zh-CN\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\zh-HK\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z
7za a bin\KeppyMIDIConverterPortable.7z bin\x64\zh-TW\KeppyMIDIConverter.resources.dll -mx9 -m0=LZMA2 -t7z