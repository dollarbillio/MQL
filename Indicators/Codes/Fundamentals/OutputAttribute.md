public sealed class OutputAttribute : Attribute

Color	Gets or sets the Color of the Output property. This Color will be used when the line for this Output is plotted.
public Colors Color{ get; set; }



//...
//The result is plotted in Turquoise.
[Output("Simple Moving Average", Color = Colors.Turquoise)] 
public IndicatorDataSeries SMA { get; set; }
public override void Calculate(int index)
{
   //...
}

public sealed enum Colors

A predefined color palette. Use these colors in indicators and other chart objects. Same as System.Drawing.Color.
Colors.AliceBlue


IsHistogram	Plots a Histogram.
public bool IsHistogram{ get; set; }

[Output("Main", IsHistogram = true)]
public IndicatorDataSeries Result { get; set; }


LineStyle	Gets or sets the Line Style for given Output property. By default it is set to Solid
public LineStyle LineStyle{ get; set; }

//...
//Simple moving average will be now plotted as Lines.
[Output("Simple Moving Average", LineStyle = LineStyle.Lines)]
public IndicatorDataSeries SMA { get; set; }
    
//...

public sealed enum LineStyle

Dots	A dotted line: .....
DotsRare	A dotted line, large gap between dots: . . . .
DotsVeryRare	A dotted line, extra large gap between dots: .   .   .   .
Lines	Lines with gaps are used to render the line: - - - -
LinesDots	A mixed line / dot style is used to render the line: - . - . - .
Solid	A solid line: -----

//Examples of all different LineStyles
[Output("Dots", LineStyle = LineStyle.Dots)]
public IndicatorDataSeries outputDots { get; set; }
[Output("DotsRare", LineStyle = LineStyle.DotsRare)]
public IndicatorDataSeries outputDotsRare { get; set; }
[Output("DotsVeryRare", LineStyle = LineStyle.DotsVeryRare)]
public IndicatorDataSeries outputDotsVeryRare { get; set; }
[Output("Lines", LineStyle = LineStyle.Lines)]
public IndicatorDataSeries outputLines { get; set; }
[Output("LinesDots", LineStyle = LineStyle.LinesDots)]
public IndicatorDataSeries outputLinesDots { get; set; }
[Output("Solid", LineStyle = LineStyle.Solid)]
public IndicatorDataSeries outputSolid { get; set; }




Name	The plot name
PlotType	Plot type.

The type of the output plotted on the output panel. Default = Line
Supported types are:
Line
Points
Histogram

public PlotType PlotType{ get; set; }

//...
//The result is plotted as a Histogram.
[Output("Commodity Channel Index", PlotType = PlotType.Histogram)]
public IndicatorDataSeries SMA { get; set; }
public override void Calculate(int index)
{
    //...
}

//...
//Plot the result as a set of yellow points.
[Output("Main", Color = Colors.Yellow, PlotType = PlotType.Points)]
public IndicatorDataSeries Result { get; set; }
//...

public sealed enum PlotType

DiscontinuousLine	Plot Indicator result as a line with breaks where there are no values in the IndicatorDataSeries.
Histogram	Plot Indicator result as a histogram.
Line	Plot Indicator result as a line.
Points	Plot Indicator result as a sequence of points.


Thickness	Sets the Width of the Output property.
public float Thickness{ get; set; }

//...
//The result is plotted as a line with thickness level five
[Output("Simple Moving Average", Thickness = 5)]
public IndicatorDataSeries SMA { get; set; }
public override void Calculate(int index)
{
    //...
}
OutputAttribute	Initializes a new instance of the OutputAttribute and sets the name.
The members have the following default values:
PlotType = PlotType.Line;
LineStyle = LineStyle.Solid;
Thickness = 1f;
Color = Colors.Green;
Name = lineName;

public OutputAttribute OutputAttribute(string lineName)

lineName	The name given to the output plot
// Simple plot that uses the default solid line plot in green color
[Output("Main")]
public IndicatorDataSeries Result { get; set; }

//Plot a simple moving average with a set of lines (dashes)
[Output("Simple Moving Average", LineStyle = LineStyle.Lines)]
public IndicatorDataSeries SMA { get; set; }

//...
//Plot a Histogram.
[Output("Commodity Channel Index", PlotType = PlotType.Histogram)]
public IndicatorDataSeries Result { get; set; }
//...



