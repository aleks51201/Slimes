using System;
using UnityEngine;

namespace Assets.SlimeEvolutions.Prefab.Slimes.Gemom.Scripts
{
    public class GeneLogic
    {
        private int slimeId;
        //private Genom.Genes typeGenes;
        private GenomeResources genomResources;

        public GeneLogic(int slimeId, Genome.Genes typeGenes)
        {
            this.slimeId = slimeId;
            //this.typeGenes = typeGenes;
            genomResources = LoadResources(typeGenes);
        }
        private GenomeResources LoadResources(Genome.Genes typeGenes)
        {
            foreach(GenomeResources res in Resources.LoadAll<GenomeResources>(""))
            {
                if(res.TypeArray == typeGenes)
                {
                    return res;
                }
            }
            throw new Exception($"Resource with type {typeGenes} not found");
        }
        private void GetImage()
        {


        }



    }
}
