using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphTestbed.Models
{
    public class OrdinalBoxPlotViewModel
    {
        private String m_title;
        private String m_xAxisLabel;
        private String m_yAxisLabel;
        private OrdinalBoxPlotItem[] m_items;

        public String Title { get { return m_title; } }
        public String XAxisLabel { get { return m_xAxisLabel; } }
        public String YAxisLabel { get { return m_yAxisLabel; } }
        public IEnumerable<OrdinalBoxPlotItem> Items { get { return m_items; }}

        public OrdinalBoxPlotViewModel(String title, String xAxisLabel, String yAxisLabel, IEnumerable<OrdinalBoxPlotItem> items)
        {
            m_title = title;
            m_xAxisLabel = xAxisLabel;
            m_yAxisLabel = yAxisLabel;
            m_items = items.ToArray();
        }
    }
}