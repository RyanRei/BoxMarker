Shader "Custom/Mask"
{
    SubShader
    {
        Tags { "Queue" = "Transparent+1" }
        ZTest Always // Ensures the mask always renders in the desired order

        Pass
        {
            Blend Zero One
        }
    }
}