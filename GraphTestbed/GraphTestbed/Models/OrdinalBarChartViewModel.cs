using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphTestbed.Models
{
    public class OrdinalBarChartViewModel
    {
        private String m_title;
        private String m_xAxisLabel;
        private String m_yAxisLabel;
        private OrdinalBarChartItem[] m_items;

        public String Title { get { return m_title; } }
        public String XAxisLabel { get { return m_xAxisLabel; } }
        public String YAxisLabel { get { return m_yAxisLabel; } }
        public IEnumerable<OrdinalBarChartItem> Items { get { return m_items; }}

        public OrdinalBarChartViewModel(String title, String xAxisLabel, String yAxisLabel, IEnumerable<OrdinalBarChartItem> items)
        {
            m_title = title;
            m_xAxisLabel = xAxisLabel;
            m_yAxisLabel = yAxisLabel;
            m_items = items.ToArray();
        }

        
    }
}