using System;
using System.Numerics;
using ILGPU;
using ILGPU.Runtime;
using ILGPU.Runtime.CPU;
using ILGPU.Runtime.Cuda;

public struct FluidCell
{
    public float DensityO2;
    public float DensityXe;
    public float Temperature;
    public Vector3 Velocity;
    public bool IsBoundary;
    public Vector3 Normal;
}

public struct SimulationParams
{
    public float DeltaTime;
    public float Viscosity;
    public float BuoyancyAlpha;
    public float BuoyancyBeta;
    public float AmbientTemperature;
    public float Gravity;
    public int SizeX;
    public int SizeY;
    public int SizeZ;
    public int ConeHeight;
    public int ConeRadius;
}
