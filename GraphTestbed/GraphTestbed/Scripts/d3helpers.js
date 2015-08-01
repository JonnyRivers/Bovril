
var d3helpers = {
    createOrdinalBarChart: function (elementSelectionText, graphData, width, height) {

        // TODO: have the graph fill the view
        // TODO: document the code
        // TODO: have values show on hover more snappily

        var graphMargin = {
            top: 70,
            right: 30,
            bottom: 40,
            left: 50
        };
        var graphWidth = width - graphMargin.left - graphMargin.right;
        var graphHeight = height - graphMargin.top - graphMargin.bottom;

        var x = d3.scale.ordinal()
            .rangeRoundBands([0, graphWidth], .1)
            .domain(graphData.Items.map(function (d) { return d.Label; }));

        // Calculate the max for our 'domain->range' function
        var maxFrequency = d3.max(graphData.Items, function (letter) {
            return letter.Value;
        });

        // Create a 'domain->range' linear transform function
        var y = d3.scale.linear()
            .domain([0, maxFrequency])
            .range([graphHeight, 0]);

        var xAxis = d3.svg.axis().scale(x).orient("bottom");

        var yAxis = d3.svg.axis().scale(y).orient("left");

        // Select the chart container using a class selector
        var graphElement = d3.select(elementSelectionText)
            .attr("width", graphWidth + graphMargin.left + graphMargin.right)
            .attr("height", graphHeight + graphMargin.top + graphMargin.bottom)
            .append("g")
            .attr("transform", "translate(" + graphMargin.left + "," + graphMargin.top + ")");

        graphElement.append("g")
            .append("text")
            .attr("class", "charttitle")
            .attr("y", -graphMargin.top / 2)
            .attr("x", graphWidth / 2)
            .style("text-anchor", "middle")
            .style("font", "24px sans-serif")
            .text(graphData.Title);

        graphElement.append("g")
            .attr("class", "x axis")
            .attr("transform", "translate(0," + graphHeight + ")")
            .call(xAxis)
            .append("text")
            .attr("class", "axislabel")
            .attr("y", 25)
            .attr("x", graphWidth / 2)
            .attr("dy", ".71em")
            .style("text-anchor", "middle")
            .style("font", "14px sans-serif")
            .text(graphData.XAxisLabel);

        graphElement.append("g")
            .attr("class", "y axis")
            .call(yAxis)
            .append("text")
            .attr("class", "axislabel")
            .attr("transform", "rotate(-90)")
            .attr("y", -graphMargin.left)
            .attr("x", -graphHeight / 2)
            .attr("dy", ".71em")
            .style("text-anchor", "middle")
            .style("font", "14px sans-serif")
            .text(graphData.YAxisLabel);

        // Setup the chart's attributes
        graphElement.attr("width", graphWidth + graphMargin.left + graphMargin.right);
        graphElement.attr("height", graphHeight + graphMargin.top + graphMargin.bottom);

        // Select the elements we want to exist
        graphElement.selectAll(".bar")
            .data(graphData.Items)
            .enter()
            .append("rect")
            .attr("x", function (d) { return x(d.Label); })
            .attr("y", function (d) { return y(d.Value); })
            .attr("height", function (d) { return graphHeight - y(d.Value); })
            .attr("width", x.rangeBand())
            .append("svg:title")
            .text(function(d, i) { return d.Label + " = " + d.Value; });
    }
}

