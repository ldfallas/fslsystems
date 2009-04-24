namespace GtkLsystemUI

import System
import Gtk
import Cairo

class DrawingWidget(DrawingArea):
   
    public def constructor():
       self.ExposeEvent += ExposeHandler
       SetSizeRequest(300,300)


    def ExposeHandler(o as object, ea as ExposeEventArgs):
   
        area = o as DrawingArea
        
        using context = Gdk.CairoHelper.Create (area.GdkWindow):
           context.Color =  Color (0,0255,0)
           context.Rectangle (0, 0, 90, 90)
           context.Fill()
           (context.Target as IDisposable).Dispose()

        ea.RetVal = true
