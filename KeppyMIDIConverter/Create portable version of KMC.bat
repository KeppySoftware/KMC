@echo off

rem License file lel
7za a "bin\Keppy's MIDI Converter - Portable.7z" license.rtf -mx9 -m0=LZMA2 -t7z

rem These are the 32-bit files
7za a "bin\Keppy's MIDI Converter - Portable.7z" "bin\x86\Restore language.bat" -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" "bin\x86\Skip update process.bat" -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x86\KeppyMIDIConverter.exe -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x86\kmcogg.exe -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x86\bass.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x86\bass_mpc.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x86\bass_vst.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x86\bassenc.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x86\bassflac.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x86\bassmidi.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x86\bassopus.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x86\basswv.dll -mx9 -m0=LZMA2 -t7z

rem These are the 64-bit ones
7za a "bin\Keppy's MIDI Converter - Portable.7z" "bin\x64\Restore language.bat" -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" "bin\x64\Skip update process.bat" -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x64\KeppyMIDIConverter.exe -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x64\kmcogg.exe -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x64\bass.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x64\bass_mpc.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x64\bass_vst.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x64\bassenc.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x64\bassflac.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x64\bassmidi.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x64\bassopus.dll -mx9 -m0=LZMA2 -t7z
7za a "bin\Keppy's MIDI Converter - Portable.7z" bin\x64\basswv.dll -mx9 -m0=LZMA2 -t7z