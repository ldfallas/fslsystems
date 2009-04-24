namespace GtkLsystemUI
import System
import Gtk

class MainWindow(Window):
   def constructor(title as string):
      super(title)
      SetDefaultSize(500, 500)
      dt = GtkLsystemUI.DrawingWidget()
      scrolledWindow = ScrolledWindow ()
      scrolledWindow.SetSizeRequest(200,200)
      scrolledWindow.AddWithViewport(dt)
      

      b = VBox(true,5)
      b.PackStart(scrolledWindow,true,true,1)
      
      notebook = Notebook()
      
      notebook.AppendPage(CreateDrawTab(),Label("Draw"))
      notebook.AppendPage(Button("A"),Label("Rules"))
      notebook.AppendPage(Button("A"),Label("Axiom"))

      bt = Button("ok")      
      b.PackStart(notebook,false,false,1)
      self.Add( b)
      DeleteEvent += { Application.Quit() }

  def CreateDrawTab():
     table = Table(3,4,false)
     table.Attach(Label("Color"),0,1,0,1)
     table.Attach(TextView(),1,2,0,1)

     table.Attach(Label("Number of iterations"),0,1,1,2)
     table.Attach(TextView(),1,2,1,2)

     table.Attach(Label("Origin"),0,1,2,3)
     table.Attach(TextView(),1,2,2,3)
     
     table.Attach(Label("Draw variables"),2,3,0,1)
     table.Attach(TextView(),3,4,0,1)

     table.Attach(Label("Number of iterations"),2,3,1,2)
     table.Attach(TextView(),3,4,1,2)

     table.Attach(Label("Segment size"),2,3,2,3)
     table.Attach(TextView(),3,4,2,3)
     

     table.RowSpacing = 5
     
     return table


