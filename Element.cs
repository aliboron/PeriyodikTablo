using CsvHelper.Configuration;

namespace PeriyodikTablo
{
    public class Element
    {
        public string Name { get; set; }
        public string Appearance { get; set; }
        public double AtomicMass { get; set; }
        public string Boil { get; set; }
        public string Category { get; set; }
        public string Density { get; set; }
        public string DiscoveredBy { get; set; }
        public string Melt { get; set; }
        public string MolarHeat { get; set; }
        public string NamedBy { get; set; }
        public int Number { get; set; }
        public int Period { get; set; }
        public string Phase { get; set; }
        public string Source { get; set; }
        public string Symbol { get; set; }
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public string Shells { get; set; }
        public string ElectronConfiguration { get; set; }
        public string ElectronConfigurationSemantic { get; set; }
        public string ElectronAffinity { get; set; }
        public string ElectronegativityPauling { get; set; }
        public string IonizationEnergies { get; set; }
        public string CpkHex { get; set; }
    }

    public class ElementClassMap : ClassMap<Element>
    {
        public ElementClassMap()
        {
            Map(m => m.Name).Name("name");
            Map(m => m.Appearance).Name("appearance");
            Map(m => m.AtomicMass).Name("atomic_mass");
            Map(m => m.Boil).Name("boil");
            Map(m => m.Category).Name("category");
            Map(m => m.Density).Name("density");
            Map(m => m.DiscoveredBy).Name("discovered_by");
            Map(m => m.Melt).Name("melt");
            Map(m => m.MolarHeat).Name("molar_heat");
            Map(m => m.NamedBy).Name("named_by");
            Map(m => m.Number).Name("number");
            Map(m => m.Period).Name("period");
            Map(m => m.Phase).Name("phase");
            Map(m => m.Source).Name("source");
            Map(m => m.Symbol).Name("symbol");
            Map(m => m.Xpos).Name("xpos");
            Map(m => m.Ypos).Name("ypos");
            Map(m => m.Shells).Name("shells");
            Map(m => m.ElectronConfiguration).Name("electron_configuration");
            Map(m => m.ElectronConfigurationSemantic).Name("electron_configuration_semantic");
            Map(m => m.ElectronAffinity).Name("electron_affinity");
            Map(m => m.ElectronegativityPauling).Name("electronegativity_pauling");
            Map(m => m.IonizationEnergies).Name("ionization_energies");
            Map(m => m.CpkHex).Name("cpk-hex");
        }
    }

}
