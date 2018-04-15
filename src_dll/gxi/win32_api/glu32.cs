/* 
 * GLU32
 * =====================================================================
 * FileName: glu32.cs
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */
using System;
using System.Runtime.InteropServices;

namespace Troya.GXI
{
    internal static class GLU32
    {
        const string LIBRARY = "glu32.dll";

        public const uint GLU_VERSION_1_1 = 1;
        public const uint GLU_VERSION_1_2 = 1;
        public const uint GLU_INVALID_ENUM = 100900;
        public const uint GLU_INVALID_VALUE = 100901;
        public const uint GLU_OUT_OF_MEMORY = 100902;
        public const uint GLU_INCOMPATIBLE_GL_VERSION = 100903;
        public const uint GLU_VERSION = 100800;
        public const uint GLU_EXTENSIONS = 100801;
        public const uint GLU_TRUE = 1;
        public const uint GLU_FALSE = 0;
        public const uint GLU_SMOOTH = 100000;
        public const uint GLU_FLAT = 100001;
        public const uint GLU_NONE = 100002;
        public const uint GLU_POINT = 100010;
        public const uint GLU_LINE = 100011;
        public const uint GLU_FILL = 100012;
        public const uint GLU_SILHOUETTE = 100013;
        public const uint GLU_OUTSIDE = 100020;
        public const uint GLU_INSIDE = 100021;
        public const double GLU_TESS_MAX_COORD = 1.0e150;
        public const uint GLU_TESS_WINDING_RULE = 100140;
        public const uint GLU_TESS_BOUNDARY_ONLY = 100141;
        public const uint GLU_TESS_TOLERANCE = 100142;
        public const uint GLU_TESS_WINDING_ODD = 100130;
        public const uint GLU_TESS_WINDING_NONZERO = 100131;
        public const uint GLU_TESS_WINDING_POSITIVE = 100132;
        public const uint GLU_TESS_WINDING_NEGATIVE = 100133;
        public const uint GLU_TESS_WINDING_ABS_GEQ_TWO = 100134;
        public const uint GLU_TESS_BEGIN = 100100;
        public const uint GLU_TESS_VERTEX = 100101;
        public const uint GLU_TESS_END = 100102;
        public const uint GLU_TESS_ERROR = 100103;
        public const uint GLU_TESS_EDGE_FLAG = 100104;
        public const uint GLU_TESS_COMBINE = 100105;
        public const uint GLU_TESS_BEGIN_DATA = 100106;
        public const uint GLU_TESS_VERTEX_DATA = 100107;
        public const uint GLU_TESS_END_DATA = 100108;
        public const uint GLU_TESS_ERROR_DATA = 100109;
        public const uint GLU_TESS_EDGE_FLAG_DATA = 100110;
        public const uint GLU_TESS_COMBINE_DATA = 100111;
        public const uint GLU_TESS_ERROR1 = 100151;
        public const uint GLU_TESS_ERROR2 = 100152;
        public const uint GLU_TESS_ERROR3 = 100153;
        public const uint GLU_TESS_ERROR4 = 100154;
        public const uint GLU_TESS_ERROR5 = 100155;
        public const uint GLU_TESS_ERROR6 = 100156;
        public const uint GLU_TESS_ERROR7 = 100157;
        public const uint GLU_TESS_ERROR8 = 100158;
        public const uint GLU_TESS_MISSING_BEGIN_POLYGON = 100151;
        public const uint GLU_TESS_MISSING_BEGIN_CONTOUR = 100152;
        public const uint GLU_TESS_MISSING_END_POLYGON = 100153;
        public const uint GLU_TESS_MISSING_END_CONTOUR = 100154;
        public const uint GLU_TESS_COORD_TOO_LARGE = 100155;
        public const uint GLU_TESS_NEED_COMBINE_CALLBACK = 100156;
        public const uint GLU_AUTO_LOAD_MATRIX = 100200;
        public const uint GLU_CULLING = 100201;
        public const uint GLU_SAMPLING_TOLERANCE = 100203;
        public const uint GLU_DISPLAY_MODE = 100204;
        public const uint GLU_PARAMETRIC_TOLERANCE = 100202;
        public const uint GLU_SAMPLING_METHOD = 100205;
        public const uint GLU_U_STEP = 100206;
        public const uint GLU_V_STEP = 100207;
        public const uint GLU_PATH_LENGTH = 100215;
        public const uint GLU_PARAMETRIC_ERROR = 100216;
        public const uint GLU_DOMAIN_DISTANCE = 100217;
        public const uint GLU_MAP1_TRIM_2 = 100210;
        public const uint GLU_MAP1_TRIM_3 = 100211;
        public const uint GLU_OUTLINE_POLYGON = 100240;
        public const uint GLU_OUTLINE_PATCH = 100241;
        public const uint GLU_NURBS_ERROR1 = 100251;
        public const uint GLU_NURBS_ERROR2 = 100252;
        public const uint GLU_NURBS_ERROR3 = 100253;
        public const uint GLU_NURBS_ERROR4 = 100254;
        public const uint GLU_NURBS_ERROR5 = 100255;
        public const uint GLU_NURBS_ERROR6 = 100256;
        public const uint GLU_NURBS_ERROR7 = 100257;
        public const uint GLU_NURBS_ERROR8 = 100258;
        public const uint GLU_NURBS_ERROR9 = 100259;
        public const uint GLU_NURBS_ERROR10 = 100260;
        public const uint GLU_NURBS_ERROR11 = 100261;
        public const uint GLU_NURBS_ERROR12 = 100262;
        public const uint GLU_NURBS_ERROR13 = 100263;
        public const uint GLU_NURBS_ERROR14 = 100264;
        public const uint GLU_NURBS_ERROR15 = 100265;
        public const uint GLU_NURBS_ERROR16 = 100266;
        public const uint GLU_NURBS_ERROR17 = 100267;
        public const uint GLU_NURBS_ERROR18 = 100268;
        public const uint GLU_NURBS_ERROR19 = 100269;
        public const uint GLU_NURBS_ERROR20 = 100270;
        public const uint GLU_NURBS_ERROR21 = 100271;
        public const uint GLU_NURBS_ERROR22 = 100272;
        public const uint GLU_NURBS_ERROR23 = 100273;
        public const uint GLU_NURBS_ERROR24 = 100274;
        public const uint GLU_NURBS_ERROR25 = 100275;
        public const uint GLU_NURBS_ERROR26 = 100276;
        public const uint GLU_NURBS_ERROR27 = 100277;
        public const uint GLU_NURBS_ERROR28 = 100278;
        public const uint GLU_NURBS_ERROR29 = 100279;
        public const uint GLU_NURBS_ERROR30 = 100280;
        public const uint GLU_NURBS_ERROR31 = 100281;
        public const uint GLU_NURBS_ERROR32 = 100282;
        public const uint GLU_NURBS_ERROR33 = 100283;
        public const uint GLU_NURBS_ERROR34 = 100284;
        public const uint GLU_NURBS_ERROR35 = 100285;
        public const uint GLU_NURBS_ERROR36 = 100286;
        public const uint GLU_NURBS_ERROR37 = 100287;

        [DllImport( LIBRARY, SetLastError = true )]
        public static unsafe extern sbyte* gluErrorString( uint errCode );
        [DllImport( LIBRARY, SetLastError = true )]
        public static unsafe extern sbyte* gluGetString( int name );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluOrtho2D( double left, double right, double bottom, double top );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluPerspective( double fovy, double aspect, double zNear, double zFar );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluPickMatrix( double x, double y, double width, double height, int[ ] viewport );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluLookAt( double eyex, double eyey, double eyez, double centerx, double centery, double centerz, double upx, double upy, double upz );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluProject( double objx, double objy, double objz, double[ ] modelMatrix, double[ ] projMatrix, int[ ] viewport, double[ ] winx, double[ ] winy, double[ ] winz );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluUnProject( double winx, double winy, double winz, double[ ] modelMatrix, double[ ] projMatrix, int[ ] viewport, ref double objx, ref double objy, ref double objz );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluScaleImage( int format, int widthin, int heightin, int typein, int[ ] datain, int widthout, int heightout, int typeout, int[ ] dataout );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluBuild1DMipmaps( uint target, uint components, int width, uint format, uint type, IntPtr data );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluBuild2DMipmaps( uint target, uint components, int width, int height, uint format, uint type, IntPtr data );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern IntPtr gluNewQuadric( );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluDeleteQuadric( IntPtr state );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluQuadricNormals( IntPtr quadObject, uint normals );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluQuadricTexture( IntPtr quadObject, int textureCoords );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluQuadricOrientation( IntPtr quadObject, int orientation );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluQuadricDrawStyle( IntPtr quadObject, uint drawStyle );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluCylinder( IntPtr qobj, double baseRadius, double topRadius, double height, int slices, int stacks );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluDisk( IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluPartialDisk( IntPtr qobj, double innerRadius, double outerRadius, int slices, int loops, double startAngle, double sweepAngle );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluSphere( IntPtr qobj, double radius, int slices, int stacks );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern IntPtr gluNewTess( );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluDeleteTess( IntPtr tess );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluTessBeginPolygon( IntPtr tess, IntPtr polygonData );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluTessBeginContour( IntPtr tess );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluTessVertex( IntPtr tess, double[ ] coords, double[ ] data );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluTessEndContour( IntPtr tess );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluTessEndPolygon( IntPtr tess );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluTessProperty( IntPtr tess, int which, double value );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluTessNormal( IntPtr tess, double x, double y, double z );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluGetTessProperty( IntPtr tess, int which, double value );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern IntPtr gluNewNurbsRenderer( );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluDeleteNurbsRenderer( IntPtr nobj );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluBeginSurface( IntPtr nobj );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluBeginCurve( IntPtr nobj );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluEndCurve( IntPtr nobj );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluEndSurface( IntPtr nobj );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluBeginTrim( IntPtr nobj );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluEndTrim( IntPtr nobj );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluPwlCurve( IntPtr nobj, int count, float array, int stride, uint type );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluNurbsCurve( IntPtr nobj, int nknots, float[ ] knot, int stride, float[ ] ctlarray, int order, uint type );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluNurbsSurface( IntPtr nobj, int sknot_count, float[ ] sknot, int tknot_count, float[ ] tknot, int s_stride, int t_stride, float[ ] ctlarray, int sorder, int torder, uint type );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluLoadSamplingMatrices( IntPtr nobj, float[ ] modelMatrix, float[ ] projMatrix, int[ ] viewport );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluNurbsProperty( IntPtr nobj, int property, float value );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void gluGetNurbsProperty( IntPtr nobj, int property, float value );
        [DllImport( LIBRARY, SetLastError = true )]
        public static extern void IntPtrCallback( IntPtr nobj, int which, IntPtr Callback );
    }
}