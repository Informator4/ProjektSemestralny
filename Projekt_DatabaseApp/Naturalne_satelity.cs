//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projekt_DatabaseApp
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Naturalne_satelity
    {
        public int Naturalna_satelitaID { get; set; }
        public Nullable<int> PlanetaID { get; set; }
        public string Nazwa_satelity { get; set; }
        public Nullable<int> Srednica_km { get; set; }
    
        public virtual Planety Planety { get; set; }
    }
}
