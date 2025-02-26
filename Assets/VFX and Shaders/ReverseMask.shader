Shader "Custom/Mask"
{
    SubShader
    {
        Tags { "Queue" = "AlphaTest+1" }
        ZWrite On
        ColorMask 0

        Pass {} // Empty pass to ensure valid syntax
    }
}
