
#light

namespace Langexplr.Lsystems

open  System
open  Microsoft.FSharp.Math.Vector 

type Point =
   {x : int; y : int }

module Funcs = begin

  let my_create_vector(i,j) =
      let result = (create 2 0.0) 
      result.[0] <- i
      result.[1] <- j
      result
end

type TurtleGraphics =
   class
     val mutable direction : vector
     val mutable position : Point
     
     new(iX,iY) = {  position = {x = iX; y = iY};  
                     direction = Funcs.my_create_vector(1.0,0.0)}

     member t.Position 
       with get() = t.position and 
            set(v) =  t.position <- {x = v.x; y = v.y }        
     
     member t.Direction
       with get() = t.direction and 
            set(v) =  t.direction <- v
     
     member t.Advance(distance : int) =
       let aX = Float.to_int (t.direction.[0] * Int32.to_float distance)
       let aY = Float.to_int (t.direction.[1] * Int32.to_float  distance)      
       t.position <- { x = aX+t.position.x;
                       y = aY+t.position.y }
       t.position
    
     member t.Rotate(angle) =
       let nI = (t.direction.[0] * Math.Cos(angle)) + (t.direction.[1] * Math.Sin(angle))
       let nJ =  (-1.0* (t.direction.[0] * Math.Sin(angle))) + (t.direction.[1] * Math.Cos(angle))       
       t.direction <- Funcs.my_create_vector(nI,nJ)
       

end
