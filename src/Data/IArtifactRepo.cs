using System.Collections.Generic;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
    public interface IArtifactRepo
    {
        bool SaveChanges();
        IEnumerable<Artifact> GetAllArtifacts();
        Artifact GetArtifactById(int id);
        void CreateArtifact(Artifact artifact);
        void UpdateArtifact(Artifact artifact);
        void DeleteArtifact(Artifact artifact);
    }
}