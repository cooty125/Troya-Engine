@echo OFF
CLS

echo Troya Engine - Cleaning solution...

RD common\Properties /s /q
RD common\bin /s /q
RD common\obj /s /q

RD gxi\Properties /s /q
RD gxi\bin /s /q
RD gxi\obj /s /q

RD libui\bin /s /q
RD libui\obj /s /q

REM @pause>nul
exit