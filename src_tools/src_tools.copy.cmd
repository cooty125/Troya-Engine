@echo OFF
CLS

echo Troya Engine - Copying tools...

CD..

MD "buildtools"
COPY "src_tools\Release\contentman.exe" "buildtools"
COPY "src_tools\Release\contentman.exe.config" "buildtools"
COPY "src_tools\Release\fntmaker.exe" "buildtools"
COPY "src_tools\Release\Microsoft.Xna.Framework.Content.Pipeline.EffectImporter.dll" "buildtools"
COPY "src_tools\Release\sha.exe" "buildtools"
COPY "src_tools\Release\xnb.exe" "buildtools"

MD "buildtools\xnbplugin_data"
COPY "src_tools\Release\xnbplugin_game.dll" "buildtools"
COPY "src_tools\Release\xnbplugin_data\game.fx" "buildtools\xnbplugin_data"
COPY "src_tools\Release\xnbplugin_data\dmap.tga" "buildtools\xnbplugin_data"
COPY "src_tools\Release\xnbplugin_data\nmap.tga" "buildtools\xnbplugin_data"
COPY "src_tools\Release\xnbplugin_data\smap.tga" "buildtools\xnbplugin_data"
COPY "src_tools\Release\xnbplugin_data\emap.tga" "buildtools\xnbplugin_data"

COPY "src_tools\Release\xnbplugin_studio.dll" "buildtools"
COPY "src_tools\Release\xnbplugin_wavefront.dll" "buildtools"

COPY "src_tools\Release\xnbthumb.exe" "buildtools"

REM @pause>nul
EXIT