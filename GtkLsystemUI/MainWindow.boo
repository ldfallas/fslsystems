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
		
		notebook.AppendPage(Button("A"),Label("Draw"))
		notebook.AppendPage(Button("A"),Label("Rules"))
		notebook.AppendPage(Button("A"),Label("Axiom"))

		bt = Button("ok")		
		b.PackStart(notebook,false,false,1)
		self.Add( b)
		DeleteEvent += { Application.Quit() }