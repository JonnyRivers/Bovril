using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphTestbed.Models
{
    public class Letter
    {
        public Letter(String text, decimal frequency)
        {
            m_text = text;
            m_frequency = frequency;
        }

        public String Text { get { return m_text; } }
        public decimal Frequency { get { return m_frequency; } }

        private readonly String m_text;
        private readonly decimal m_frequency;
    }
}