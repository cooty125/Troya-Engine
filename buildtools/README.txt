 
  Troya Engine - Tools Usage
==============================


------------------------------
 SHA Compiler
------------------------------
sha.exe /fx <shader_source_filename.fx>
sha.exe /fx <shader_source_filename.fx> /outdir <output_directory>

Output: <shader_source_filename.sha>
------------------------------


------------------------------
 XNB Binary Builder
------------------------------
XNB_TYPE: 	TEXTURE; FONT; MODEL; STUDIOMODEL; GAMEMODEL; SOUND;
GD_PROFILE: 	HIDEF; REACH;

xnb.exe /source <source_filename> /type <XNB_TYPE>
xnb.exe /source <source_filename> /type <XNB_TYPE> /outdir <output_directory>
xnb.exe /source <source_filename> /type <XNB_TYPE> /profile <GD_PROFILE> /outdir <output_directory>

Output: <source_filename.xnb>
------------------------------


------------------------------
 XNB Thumbnail
------------------------------
xnbthumb.exe /xnb <xnb_source_filename.xnb> /content <content_directory>
xnbthumb.exe /xnb <xnb_source_filename.xnb> /content <content_directory> /outdir <output_directory>
xnbthumb.exe /xnb <xnb_source_filename.xnb> /content <content_directory> /size <thumbnail_size> /outdir <output_directory>

Output: <xnb_source_filename.png>
------------------------------
