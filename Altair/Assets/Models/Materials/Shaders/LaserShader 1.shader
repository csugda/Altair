// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32889,y:32674,varname:node_4795,prsc:2|emission-441-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:31978,y:32552,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3538ed48b7a825543953b5ddee134e3d,ntxv:0,isnm:False|UVIN-9611-OUT;n:type:ShaderForge.SFN_Multiply,id:2393,x:32744,y:32807,varname:node_2393,prsc:2|B-2053-RGB,C-797-RGB,D-9248-OUT,E-9922-OUT;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32445,y:32816,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:32367,y:32966,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Vector1,id:9248,x:32387,y:33129,varname:node_9248,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:9922,x:32629,y:33028,varname:node_9922,prsc:2|A-6074-A,B-797-A,C-3850-A,D-3290-A;n:type:ShaderForge.SFN_Time,id:2072,x:31156,y:32425,varname:node_2072,prsc:2;n:type:ShaderForge.SFN_Append,id:6613,x:31339,y:32724,varname:node_6613,prsc:2|A-7715-OUT,B-1625-OUT;n:type:ShaderForge.SFN_Multiply,id:4389,x:31544,y:32626,varname:node_4389,prsc:2|A-2072-T,B-6613-OUT;n:type:ShaderForge.SFN_TexCoord,id:8215,x:31544,y:32463,varname:node_8215,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:9611,x:31756,y:32595,varname:node_9611,prsc:2|A-8215-UVOUT,B-4389-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7715,x:31139,y:32608,ptovrint:False,ptlb:X Value,ptin:_XValue,varname:node_7715,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-1;n:type:ShaderForge.SFN_ValueProperty,id:1625,x:31139,y:32768,ptovrint:False,ptlb:Y Value,ptin:_YValue,varname:node_1625,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Tex2d,id:3850,x:32006,y:32772,ptovrint:False,ptlb:node_3850,ptin:_node_3850,varname:node_3850,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3538ed48b7a825543953b5ddee134e3d,ntxv:0,isnm:False|UVIN-8627-OUT;n:type:ShaderForge.SFN_Add,id:3915,x:32235,y:32629,varname:node_3915,prsc:2|A-6074-RGB,B-3850-RGB,C-3290-RGB;n:type:ShaderForge.SFN_Time,id:2842,x:31389,y:32946,varname:node_2842,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4502,x:31625,y:33093,varname:node_4502,prsc:2|A-2842-T,B-5039-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9912,x:30963,y:33028,ptovrint:False,ptlb:X Value2,ptin:_XValue2,varname:node_9912,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-2;n:type:ShaderForge.SFN_ValueProperty,id:9327,x:30963,y:33143,ptovrint:False,ptlb:Y value2,ptin:_Yvalue2,varname:node_9327,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:5039,x:31329,y:33093,varname:node_5039,prsc:2|A-9912-OUT,B-9327-OUT;n:type:ShaderForge.SFN_TexCoord,id:3445,x:31605,y:32936,varname:node_3445,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:8627,x:31834,y:32936,varname:node_8627,prsc:2|A-3445-UVOUT,B-4502-OUT;n:type:ShaderForge.SFN_Tex2d,id:3290,x:31981,y:33150,ptovrint:False,ptlb:node_3290,ptin:_node_3290,varname:node_3290,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9d62caebcce58684e9f241d84ed22e25,ntxv:0,isnm:False|UVIN-5690-OUT;n:type:ShaderForge.SFN_Multiply,id:441,x:32444,y:32680,varname:node_441,prsc:2|A-3290-RGB,B-3915-OUT;n:type:ShaderForge.SFN_Time,id:5219,x:31099,y:33286,varname:node_5219,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:6822,x:31082,y:33469,ptovrint:False,ptlb:X Value_copy,ptin:_XValue_copy,varname:_XValue_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:-1;n:type:ShaderForge.SFN_ValueProperty,id:7759,x:31082,y:33629,ptovrint:False,ptlb:Y Value_copy,ptin:_YValue_copy,varname:_YValue_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:1794,x:31282,y:33585,varname:node_1794,prsc:2|A-6822-OUT,B-7759-OUT;n:type:ShaderForge.SFN_Multiply,id:2019,x:31487,y:33487,varname:node_2019,prsc:2|A-5219-T,B-1794-OUT;n:type:ShaderForge.SFN_TexCoord,id:3895,x:31487,y:33324,varname:node_3895,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:5690,x:31699,y:33456,varname:node_5690,prsc:2|A-3895-UVOUT,B-2019-OUT;proporder:6074-797-1625-7715-3850-9912-9327-3290-6822-7759;pass:END;sub:END;*/

Shader "Shader Forge/LaserShader" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.5,0.5,0.5,1)
        _YValue ("Y Value", Float ) = 0
        _XValue ("X Value", Float ) = -1
        _node_3850 ("node_3850", 2D) = "white" {}
        _XValue2 ("X Value2", Float ) = -2
        _Yvalue2 ("Y value2", Float ) = 0
        _node_3290 ("node_3290", 2D) = "white" {}
        _XValue_copy ("X Value_copy", Float ) = -1
        _YValue_copy ("Y Value_copy", Float ) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _XValue;
            uniform float _YValue;
            uniform sampler2D _node_3850; uniform float4 _node_3850_ST;
            uniform float _XValue2;
            uniform float _Yvalue2;
            uniform sampler2D _node_3290; uniform float4 _node_3290_ST;
            uniform float _XValue_copy;
            uniform float _YValue_copy;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_5219 = _Time;
                float2 node_5690 = (i.uv0+(node_5219.g*float2(_XValue_copy,_YValue_copy)));
                float4 _node_3290_var = tex2D(_node_3290,TRANSFORM_TEX(node_5690, _node_3290));
                float4 node_2072 = _Time;
                float2 node_9611 = (i.uv0+(node_2072.g*float2(_XValue,_YValue)));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_9611, _MainTex));
                float4 node_2842 = _Time;
                float2 node_8627 = (i.uv0+(node_2842.g*float2(_XValue2,_Yvalue2)));
                float4 _node_3850_var = tex2D(_node_3850,TRANSFORM_TEX(node_8627, _node_3850));
                float3 emissive = (_node_3290_var.rgb*(_MainTex_var.rgb+_node_3850_var.rgb+_node_3290_var.rgb));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0.5,0.5,0.5,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
