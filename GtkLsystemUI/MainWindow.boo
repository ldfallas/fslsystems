namespace GtkLsystemUI
import System
import Gtk

class MainWindow(Window):
	def constructor(title as string):
		super(title)
		SetDefaultSize(400, 300)
		dt = GtkLsystemUI.DrawingWidget()
		scrolledWindow = ScrolledWindow ()
		scrolledWindow.SetSizeRequest(200,200)
		scrolledWindow.AddWithViewport(dt)
		

		b = VBox(true,5)
		b.PackStart(scrolledWindow,true,true,1)
		bt = Button("ok")
		
		b.PackStart(bt,false,false,1)
		self.Add( b)
		DeleteEvent += { Application.Quit() }