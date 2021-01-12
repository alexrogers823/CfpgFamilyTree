using System;
using System.Collections.Generic;
using System.Linq;
using CfpgFamilyTree.Models;

namespace CfpgFamilyTree.Data
{
  public class SqlArtifactRepo : IArtifactRepo
  {
    private readonly CfpgContext _context;

    public SqlArtifactRepo(CfpgContext context)
      {
          _context = context;
      }
    public void CreateArtifact(Artifact artifact)
    {
        if (artifact == null)
        {
            throw new ArgumentNullException(nameof(artifact));
        }

        _context.Artifacts.Add(artifact);
    }

    public void DeleteArtifact(Artifact artifact)
    {
        if (artifact == null)
        {
            throw new ArgumentNullException(nameof(artifact));
        }

        _context.Artifacts.Remove(artifact);
    }

    public IEnumerable<Artifact> GetAllArtifacts()
    {
        return _context.Artifacts.ToList();
    }

    public Artifact GetArtifactById(int id)
    {
        return _context.Artifacts.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public void UpdateArtifact(Artifact artifact)
    {
        
    }
  }
}