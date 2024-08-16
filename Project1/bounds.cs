using System;

private void SetBoundsKernel(
    Index2 index,
    ArrayView2D<FluidCell> grid,
    SimulationParams simParams)
{
    int x = index.X;
    int y = index.Y;

    if (x==0||x==simParams.SizeX-1||y==0||y==simParams.SizeY-1)
    {
        grid[index].Velocity=Vector3.Zero;
        grid[index].DensityO2=0;
        grid[index].DensityXe=0;
        grid[index].Temperature=simParams.AmbientTemperature;
    }
    else if (grid[index].IsBoundary)
    {
        Vector3 normal = grid[index].Normal;
        grid[index].Velocity=Vector3.Reflect(grid[index].Velocity, normal);
    }
}
