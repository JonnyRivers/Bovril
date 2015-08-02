using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphTestbed.Models
{
    public class OrdinalBoxPlotItem
    {
        public OrdinalBoxPlotItem(
            String label, 
            decimal minimum, 
            decimal lowerQuartile, 
            decimal median,
            decimal upperQuartile, 
            decimal maximum)
        {
            m_label = label;
            m_minimum = minimum;
            m_lowerQuartile = lowerQuartile;
            m_median = median;
            m_upperQuartile = upperQuartile;
            m_maximum = maximum;
        }

        public String Label { get { return m_label; } }
        public decimal Minimum { get { return m_minimum; } }
        public decimal LowerQuartile { get { return m_lowerQuartile; } }
        public decimal Median { get { return m_median; } }
        public decimal UpperQuartile { get { return m_upperQuartile; } }
        public decimal Maximum { get { return m_maximum; } }

        private readonly String m_label;
        private readonly decimal m_minimum;
        private readonly decimal m_lowerQuartile;
        private readonly decimal m_median;
        private readonly decimal m_upperQuartile;
        private readonly decimal m_maximum;
    }
}