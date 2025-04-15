using System.Collections.Generic;

public interface IParticleFactory
{
    public List<ParticleController[]> CreateParticle();
}