@echo OFF
CLS

echo Troya Engine - Cleaning solution...

RD contentman\bin /s /q
RD contentman\obj /s /q

RD fntmaker\bin /s /q
RD fntmaker\obj /s /q

RD sha\Properties /s /q
RD sha\bin /s /q
RD sha\obj /s /q

RD xnb\Properties /s /q
RD xnb\bin /s /q
RD xnb\obj /s /q

RD xnbplugin_game\Properties /s /q
RD xnbplugin_game\bin /s /q
RD xnbplugin_game\obj /s /q

RD xnbplugin_studio\Properties /s /q
RD xnbplugin_studio\bin /s /q
RD xnbplugin_studio\obj /s /q

RD xnbplugin_wavefront\Properties /s /q
RD xnbplugin_wavefront\bin /s /q
RD xnbplugin_wavefront\obj /s /q

RD xnbthumb\Properties /s /q
RD xnbthumb\bin /s /q
RD xnbthumb\obj /s /q

REM @pause>nul
exit