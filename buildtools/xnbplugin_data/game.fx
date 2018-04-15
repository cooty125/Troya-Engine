/* 
 * Game Shader
 * =====================================================================
 * FileName: game.fx
 * ---------------------------------------------------------------------
 * This document is distributed under GNU General Public License.
 * Copyright © David Kutnar 2018 - All rights reserved.
 * =====================================================================
 */

float4x4 Transform;
float4x4 View;
float4x4 Projection;

float4x4 TransformView;
float4x4 TransformViewProjection;

float CameraFarPlane;

float4x4 LightMatrix;
float2 LightBufferPS;

const static float LightBufferScaleInverted = 100;



texture DiffuseMap;
sampler DiffuseMapSampler = sampler_state {
	Texture = (DiffuseMap);
	MAGFILTER = LINEAR;
	MINFILTER = LINEAR;
	MIPFILTER = LINEAR;
	AddressU = WRAP;
	AddressV = WRAP;
};

texture NormalMap;
sampler NormalMapSampler = sampler_state {
	Texture = (NormalMap);
	MAGFILTER = LINEAR;
	MINFILTER = LINEAR;
	MIPFILTER = LINEAR;
	AddressU = WRAP;
	AddressV = WRAP;
};

texture SpecularMap;
sampler SpecularMapSampler = sampler_state {
	Texture = (SpecularMap);
	MAGFILTER = LINEAR;
	MINFILTER = LINEAR;
	MIPFILTER = LINEAR;
	AddressU = WRAP;
	AddressV = WRAP;
};

texture EmissiveMap;
sampler EmissiveMapSampler = sampler_state {
	Texture = (EmissiveMap);
	MAGFILTER = LINEAR;
	MINFILTER = LINEAR;
	MIPFILTER = LINEAR;
	AddressU = WRAP;
	AddressV = WRAP;
};

texture LightBufferTexture;
sampler2D LightTextureSampler = sampler_state
{
	Texture = <LightBufferTexture>;
	MipFilter = POINT;
	MagFilter = POINT;
	MinFilter = POINT;
	AddressU = CLAMP;
	AddressV = CLAMP;
};



half2 encodeNormal ( half3 n ) {
	float2 enc = ( n.xy / ( n.z + 1 ) );
	enc /= 1.7777;
	enc = ( enc * 0.5 + 0.5 );

	return enc;
}
float2 convertPPSToSPS( float4 pos ) {
	float2 screenPos = ( pos.xy / pos.w );
	return ( 0.5 * ( float2( screenPos.x, -screenPos.y ) + 1 ) );
}
half3 computeNormalVS( half3 normalMap, float3 normal, float3 binormal, float3 tangent ) {
	normalMap = ( normalMap * 2 - 1 );
	normalMap = half3( normal * normalMap.z + normalMap.x * tangent - normalMap.y * binormal );
	return normalMap;
}	



struct VS_GBuffer_In {
    float4 Position		: POSITION0;
    float2 TexCoord		: TEXCOORD0;
    float3 Normal		: NORMAL0;    
    //float3 Binormal	: BINORMAL0;
    float4 Tangent		: TANGENT;
};

struct VS_GBuffer_Out {
    float4 Position		: POSITION0;
    float2 TexCoord		: TEXCOORD0;
    float Depth			: TEXCOORD1;
    float3 Normal		: TEXCOORD2;
    float3 Tangent		: TEXCOORD3;
    float3 Binormal		: TEXCOORD4; 
};

struct PS_GBuffer_Out {
    float4 Normal		: COLOR0;
    float4 Depth		: COLOR1;
};



VS_GBuffer_Out VS_GBuffer( VS_GBuffer_In input ) {
	float3 viewSpacePos = mul( input.Position, TransformView );

    VS_GBuffer_Out output = ( VS_GBuffer_Out )0;
    output.Position = mul( input.Position, TransformViewProjection );
    output.TexCoord = input.TexCoord;
	output.Normal = normalize( mul( input.Normal, TransformView ) ); 
	output.Tangent =  normalize( mul( input.Tangent.xyz, TransformView ) ); 
	output.Binormal =  normalize( cross( output.Normal, output.Tangent ) * input.Tangent.w );
	output.Depth = viewSpacePos.z;

    return output;
}



PS_GBuffer_Out PS_GBuffer( VS_GBuffer_Out input ) {
	half4 normalMap = tex2D( NormalMapSampler, input.TexCoord );
	half3 normalVS = computeNormalVS( normalMap.xyz, input.Normal, input.Binormal, input.Tangent );

	PS_GBuffer_Out output = ( PS_GBuffer_Out )1;   
	output.Normal.rg = encodeNormal( normalize( normalVS ) );
	output.Normal.b = normalMap.a;
	output.Normal.a = 1;
	output.Depth.x = ( -input.Depth / CameraFarPlane );
	
	return output;
}



struct VS_Shading_In {
    float4 Position		: POSITION0;
    float2 TexCoord		: TEXCOORD0;
};

struct VS_Shading_Out
{
    float4 Position		: POSITION0;
    float2 TexCoord		: TEXCOORD0;
	float4 TexCoordSS	: TEXCOORD1;
};

struct PS_Shading_Out {
	float4 Color		: COLOR0;
};



VS_Shading_Out VS_Shading( VS_Shading_In input ) {
    VS_Shading_Out output = ( VS_Shading_Out )0;
	output.Position = mul( input.Position, TransformViewProjection );
    output.TexCoord = input.TexCoord;
	output.TexCoordSS = output.Position;

    return output;
}



PS_Shading_Out PS_Shading( VS_Shading_Out input ) {
	float2 screenPos = ( convertPPSToSPS( input.TexCoordSS ) + LightBufferPS );

	half3 diffuseMap = tex2D( DiffuseMapSampler, input.TexCoord ).rgb;
	half3 specularMap = tex2D( SpecularMapSampler, input.TexCoord ).rgb;
	half3 emissiveMap = tex2D( EmissiveMapSampler, input.TexCoord ).rgb;
	
	float4 lightColor = ( tex2D( LightTextureSampler, screenPos ) * LightBufferScaleInverted );
	float3 specular = ( lightColor.rgb * lightColor.a );

	float4 finalColor = float4( diffuseMap * lightColor.rgb + specular * specularMap + emissiveMap, 1 );
	finalColor.rgb += ( diffuseMap * 0.1 );

	PS_Shading_Out output = ( PS_Shading_Out )1; 
	output.Color = finalColor;

	return output;
}



struct VS_ShadowMap_In {
    float4 Position		: POSITION0;	
};

struct VS_ShadowMap_Out {
    float4 Position		: POSITION0;
	float2 Depth		: TEXCOORD0;
};

struct PS_ShadowMap_Out {
	float4 Depth		: COLOR0;
};



VS_ShadowMap_Out VS_ShadowMap( VS_ShadowMap_In input ) {
    float4 clipPosition = mul( input.Position, mul( Transform, LightMatrix ) );
	clipPosition.z = max( clipPosition.z, 0 );
	
	VS_ShadowMap_Out output = ( VS_ShadowMap_Out )0;
	output.Position = clipPosition;
	output.Depth = output.Position.zw;

    return output;
}



PS_ShadowMap_Out PS_ShadowMap( VS_ShadowMap_Out input ) {
    float depth = ( input.Depth.x / input.Depth.y );

	PS_ShadowMap_Out output = ( PS_ShadowMap_Out )1;
	output.Depth = float4( depth, 1, 1, 1 ); 

    return output;
}



technique GBuffer {
    pass Default {
        VertexShader = compile vs_2_0 VS_GBuffer( );
        PixelShader = compile ps_2_0 PS_GBuffer( );
    }
}

technique Shading {
	pass Default {
        VertexShader = compile vs_2_0 VS_Shading( );
        PixelShader = compile ps_2_0 PS_Shading( );
    }
}

technique ShadowMap {
	pass Default {		
        VertexShader = compile vs_3_0 VS_ShadowMap( );
        PixelShader = compile ps_3_0 PS_ShadowMap( );
	}
}