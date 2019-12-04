namespace wf_testLabs.model.entities
{
    class CCoolerProduct
    {
        public int Id { get; set; }
        public double Amount { get; set; }

        public int? CoolerId { get; set; }
        public CCooler Cooler { get; set; }
        public int? ProductId { get; set; }
        public CProduct Product { get; set; }
    }
}
