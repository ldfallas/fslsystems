using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Langexplr.Lsystems;


namespace WpfPolyTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            rulesTextBox.Text = "X -> F-[[X]+X]+F[+FX]-X\nF -> FF";
        }

        #region old code

        /*
        public List<PointCollection> GetPlant()
        {
          
            Rule r1 = Rule.Rule(
                LsystemElement.Var("X"),
                Microsoft.FSharp.Collections.ListModule.of_IEnumerable<List<LsystemElement>, LsystemElement>(
                new List<LsystemElement>             {
            LsystemElement.Var("F"),
            LsystemElement.Constant("-"),
            LsystemElement.Constant("["),
            LsystemElement.Constant("["),
            LsystemElement.Var("X"),
            LsystemElement.Constant("]"),
            LsystemElement.Constant("+"),
            LsystemElement.Var("X"),
            LsystemElement.Constant("]"),
            LsystemElement.Constant("+"),
            LsystemElement.Var("F"),
            LsystemElement.Constant("["),
            LsystemElement.Constant("+"),
            LsystemElement.Var("F"),
            LsystemElement.Var("X"),
            LsystemElement.Constant("]"),
            LsystemElement.Constant("-"),
            LsystemElement.Var("X")}
                ));

            Rule r2 = Rule.Rule(
                LsystemElement.Var("F"),
                Microsoft.FSharp.Collections.ListModule.of_IEnumerable<List<LsystemElement>, LsystemElement>(
                new List<LsystemElement>             {
            LsystemElement.Var("F"),LsystemElement.Var("F")}
                ));


            TurtleGraphicsLsystemProcessor tgls =
                new TurtleGraphicsLsystemProcessor(
                    Microsoft.FSharp.Collections.ListModule.of_array<LsystemElement>(new LsystemElement[] { LsystemElement.Var("X") }),
                    25,
                    Microsoft.FSharp.Collections.ListModule.of_array<Rule>(new Rule[] { r1,r2 }),
                    5,
                    true);


            TurtleGraphics tg = new TurtleGraphics(250, 250);



            return new List<PointCollection>(
                from pc in (tgls.generate_iteration(5)).Invoke(tg)
                select (new PointCollection(
                          from p in pc
                          select new System.Windows.Point(p.x, p.y)))
                );

        }


        public List<PointCollection> GetPlant2()
        {

            Rule r1 = Rule.Rule(
                LsystemElement.Var("F"),
                Microsoft.FSharp.Collections.ListModule.of_IEnumerable<List<LsystemElement>, LsystemElement>(
                new List<LsystemElement>             {
         
            LsystemElement.Var("F"),
            LsystemElement.Constant("["),
            LsystemElement.Constant("+"),
            LsystemElement.Var("F"),
            LsystemElement.Constant("]"),
            LsystemElement.Var("F"),
             LsystemElement.Constant("["),
            LsystemElement.Constant("-"),
            LsystemElement.Var("F"),
            LsystemElement.Constant("]"),
            LsystemElement.Var("F"),

            //LsystemElement.Constant("]")
                }
                ));




            TurtleGraphicsLsystemProcessor tgls =
                new TurtleGraphicsLsystemProcessor(
                    Microsoft.FSharp.Collections.ListModule.of_array<LsystemElement>(new LsystemElement[] { LsystemElement.Var("F") }),
                    14,
                    Microsoft.FSharp.Collections.ListModule.of_array<Rule>(new Rule[] { r1 }),
                    5,true);


            TurtleGraphics tg = new TurtleGraphics(250, 250);



            return new List<PointCollection>(
                from pc in (tgls.generate_iteration(5)).Invoke(tg)
                select (new PointCollection(
                          from p in pc
                          select new System.Windows.Point(p.x, p.y)))
                );

        }

        public List<PointCollection> GetPlant3()
        {

            Rule r1 = Rule.Rule(
                LsystemElement.Var("F"),
                Microsoft.FSharp.Collections.ListModule.of_IEnumerable<List<LsystemElement>, LsystemElement>(
                new List<LsystemElement>             {
         
            LsystemElement.Var("F"),
            LsystemElement.Constant("["),
            LsystemElement.Constant("+"),
            LsystemElement.Var("F"),
            LsystemElement.Constant("]"),
            LsystemElement.Constant("["),
            LsystemElement.Constant("-"),
            LsystemElement.Var("F"),
            LsystemElement.Constant("]"),


            //LsystemElement.Constant("]")
                }
                ));




            TurtleGraphicsLsystemProcessor tgls =
                new TurtleGraphicsLsystemProcessor(
                    Microsoft.FSharp.Collections.ListModule.of_array<LsystemElement>(new LsystemElement[] { LsystemElement.Var("F") }),
                    45,
                    Microsoft.FSharp.Collections.ListModule.of_array<Rule>(new Rule[] { r1 }),
                    15,true);


            TurtleGraphics tg = new TurtleGraphics(250, 250);



            return new List<PointCollection>(
                from pc in (tgls.generate_iteration(1)).Invoke(tg)
                select (new PointCollection(
                          from p in pc
                          select new System.Windows.Point(p.x, p.y)))
                );

        }

        public List<PointCollection> GetKoch()               
        {
            //(A → B−A−B),(B → A+B+A)
            Rule r1 = Rule.Rule(
                LsystemElement.Var("F"),
                Microsoft.FSharp.Collections.ListModule.of_IEnumerable<List<LsystemElement>, LsystemElement>(
                new List<LsystemElement>             {
            LsystemElement.Var("F"),LsystemElement.Constant("+"),
            LsystemElement.Var("F"),LsystemElement.Constant("-"),
            LsystemElement.Var("F"),LsystemElement.Constant("-"),
            LsystemElement.Var("F"),LsystemElement.Constant("+"),
            LsystemElement.Var("F")}
                ));

            TurtleGraphicsLsystemProcessor tgls =
                new TurtleGraphicsLsystemProcessor(
                    Microsoft.FSharp.Collections.ListModule.of_array<LsystemElement>(new LsystemElement[]{LsystemElement.Var("F")}),
                    90,
                    Microsoft.FSharp.Collections.ListModule.of_array<Rule>(new Rule[]{r1}),
                    5,true);


            TurtleGraphics tg = new TurtleGraphics(100, 100);



            return new List<PointCollection>(
                from pc in (tgls.generate_iteration(3)).Invoke(tg)
                select (new PointCollection(
                          from p in pc
                          select new System.Windows.Point(p.x, p.y)))
                );


        }
        public List<PointCollection> GetSierpinski()
        {
            //(A → B−A−B),(B → A+B+A)
            Rule r1 = Rule.Rule(
                LsystemElement.Var("A"),
                Microsoft.FSharp.Collections.ListModule.of_IEnumerable<List<LsystemElement>, LsystemElement>(
                new List<LsystemElement>             {
            LsystemElement.Var("B"),LsystemElement.Constant("-"),
            LsystemElement.Var("A"),LsystemElement.Constant("-"),
            LsystemElement.Var("B")}
                ));
            Rule r2 = Rule.Rule(
               LsystemElement.Var("B"),
               Microsoft.FSharp.Collections.ListModule.of_IEnumerable<List<LsystemElement>, LsystemElement>(
               new List<LsystemElement>             {
            LsystemElement.Var("A"),LsystemElement.Constant("+"),
            LsystemElement.Var("B"),LsystemElement.Constant("+"),
            LsystemElement.Var("A")}
               ));

            TurtleGraphicsLsystemProcessor tgls =
                new TurtleGraphicsLsystemProcessor(
                    Microsoft.FSharp.Collections.ListModule.of_array<LsystemElement>(new LsystemElement[]{LsystemElement.Var("A")}),
                    60,
                    Microsoft.FSharp.Collections.ListModule.of_array<Rule>(new Rule[]{r1,r2}),
                    5,true);


            TurtleGraphics tg = new TurtleGraphics(50, 50);



            return new List<PointCollection>(
                from pc in (tgls.generate_iteration(3)).Invoke(tg)
                select (new PointCollection(
                          from p in pc
                          select new System.Windows.Point(p.x, p.y)))
                );


        }

        public List<System.Windows.Point> GetTurtleGraphicsPoints()
        {
            TurtleGraphics tg = new TurtleGraphics(50, 50);
            List<System.Windows.Point> result = new List<System.Windows.Point>();
            result.Add(new System.Windows.Point(tg.Position._x,tg.Position._y));
            tg.Advance(10);            
            result.Add(new System.Windows.Point(tg.Position._x,tg.Position._y));
            tg.Rotate(Math.PI / 2);
            tg.Advance(10); 
            result.Add(new System.Windows.Point(tg.Position._x, tg.Position._y));
            tg.Rotate(Math.PI / 4);
            tg.Advance(10);
            result.Add(new System.Windows.Point(tg.Position._x, tg.Position._y));
            return result;
        }*/

        #endregion

        private void b_Click(object sender, RoutedEventArgs e)
        {
            string origin = this.originTB.Text;
            int originX = 50;
            int originY = 50;
            string[] oparts = origin.Split(',');
            if (oparts.Length == 2)
            {
                originX = int.Parse(oparts[0]);
                originY = int.Parse(oparts[1]);
            }

            TurtleGraphics tg = new TurtleGraphics(originX, originY);
            int iterations = int.Parse(this.iterationsTB.Text);

            this.canvas1.Children.Clear();

            List<Rule> rules = GetRules();

            TurtleGraphicsLsystemProcessor tgls =
                new TurtleGraphicsLsystemProcessor(
                    LsystemFuncs.getLsystemElements(this.axiomTextBox.Text),
                    int.Parse(this.angleTB.Text),
                    Microsoft.FSharp.Collections.Seq.to_list<Rule>(rules),
                    int.Parse(this.segmentSizeTB.Text),
                    drawVariablesTB.Text.Split(','),
                    clearFonEveryIterationCB.IsChecked.Value);

            var pointCollections =
                from pc in (tgls.generate_iteration(int.Parse(this.iterationsTB.Text))).Invoke(tg)
                select (new PointCollection(
                          from p in pc
                          select new System.Windows.Point(p.x, p.y)));

            foreach (PointCollection pcol in pointCollections)
            {
                Polyline pLine = new Polyline();

                pLine.Points = pcol;
                pLine.Stroke = this.colorButton.Background;
                this.canvas1.Children.Add(pLine);
            }
        }

        private List<Rule> GetRules()
        {
            List<Rule> rules = new List<Rule>();
            string[] lines = this.rulesTextBox.Text.Split('\n');

            foreach (string iline in lines)
            {
                string line = iline.Trim();
                if (line.Length > 0 && line.IndexOf("->") != -1)
                {
                    int index = line.IndexOf("->");
                    string pre = line.Substring(0, index).Trim();
                    string post = line.Substring(index + 2).Trim();
                    if (pre.Length != 0 && post.Length != 0)
                    {
                        rules.Add(new Rule(LsystemFuncs.getLsystemElements(pre).First(),
                                           LsystemFuncs.getLsystemElements(post)));

                    }

                }
            }
            return rules;
        }

        private void colorButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
            System.Windows.Forms.DialogResult result = colorDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Color c = Color.FromRgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);


                this.colorButton.Background =
                    new SolidColorBrush(c);

            }
        }
    }
}
