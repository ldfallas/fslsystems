
#light

namespace Langexplr.Lsystems

open Langexplr.Lsystems

open  System

type LsystemElement =
   | Var of String
   | Constant of String   
   | PipeCommand of int
     
type Rule =
   | Rule of LsystemElement * LsystemElement list

module LsystemFuncs = begin
  let rec gettingLsystemElements (str:string) i result =
     if str.Length > i then
       if  System.Char.IsLetterOrDigit(str.[i]) then
         gettingLsystemElements str (i+1) ((Var(str.[i].ToString()))::result)
       else
         gettingLsystemElements str (i+1) ((Constant(str.[i].ToString()))::result)
     else
        List.rev result
 let getLsystemElements str =
     gettingLsystemElements str 0 []
end


type TurtleGraphicsLsystemProcessor =
  class
    val start : LsystemElement list
    val angle : double
    val rules : Rule list
    val seg_size : int
    val mutable saved_positions : Point list
    val mutable saved_directions : vector list
    val drawVariables : string array
    val clearFEveryIt : bool
    
    new (a_start,a_angle,t_rules,s_size,drawVars,clearFEveryIt) = { 
       start = a_start; 
       angle = (Math.PI/180.0)* a_angle; 
       rules = t_rules; 
       seg_size = s_size;
       saved_positions = [];
       saved_directions = [];
       drawVariables = drawVars
       clearFEveryIt = clearFEveryIt}
               
    member lp.generate_for n current =
      let fFunc = 
           if lp.clearFEveryIt 
              then (fun e -> match e with | Var "F" -> false | _ -> true) 
              else (fun e -> true)
           in
       match n with
       | 0 -> current
       | o -> lp.generate_for (n - 1) (lp.apply_rules (List.filter fFunc current) n)
    
    member lp.apply_rules elements iteration =
       match elements with
       | ((Var v)::rest) -> List.append (lp.apply_rule_for v) (lp.apply_rules rest iteration)
       | ((Constant "|")::rest) -> (PipeCommand iteration)::(lp.apply_rules rest iteration)
       | (e::rest) -> e::(lp.apply_rules rest iteration)
       | [] -> elements
    
    member lp.apply_rule_for v =
       match (List.tryfind (fun r -> match r with
                                     | Rule(Var vvar,_) when vvar = v -> true
                                     | _ -> false) 
                    lp.rules) with
       | Some (Rule(_, result)) -> result
       | None -> [Var v]
       
      
    member lp.generate_iteration n (tg:TurtleGraphics)=
       let final = lp.generate_for n lp.start
       in 
          List.rev(lp.generate_points n final tg [tg.Position] [])
          
    member lp.generate_points iterations elements (tg:TurtleGraphics) current lines =
       match elements with
       | ((Var v)::rest) -> 
             match (Array.tryfind (fun dv -> String.lowercase(v) = String.lowercase(dv)) lp.drawVariables) with
             | Some _ -> 
                 let _ = tg.Advance(lp.seg_size) in
                       lp.generate_points iterations rest tg (tg.Position::current) lines
             | _ -> lp.generate_points iterations rest tg current lines
       | ((Constant "+")::rest) -> 
             tg.Rotate(lp.angle)
             lp.generate_points iterations rest tg current lines
       | ((Constant "-")::rest) -> 
             tg.Rotate(-1.0*lp.angle)
             lp.generate_points iterations rest tg current lines
       | ((Constant "[")::rest) -> 
             lp.saved_directions <- tg.Direction::lp.saved_directions
             lp.saved_positions <- tg.Position::lp.saved_positions
             lp.generate_points iterations rest tg current lines
       | ((Constant "]")::rest) -> 
             match (lp.saved_directions,lp.saved_positions) with
             | (cdir::rest_dir,cpos::rest_pos) -> 
                  lp.saved_directions <- rest_dir
                  lp.saved_positions <- rest_pos
                  tg.Position <- cpos
                  tg.Direction <- cdir
                  lp.generate_points iterations rest tg [tg.Position] (current::lines)
             | _ -> lp.generate_points iterations rest tg current lines 
       | ((Constant "|")::rest) -> 
             let _ = tg.Advance(lp.seg_size / (iterations) ) in
             lp.generate_points iterations rest tg (tg.Position::current) lines
       | ((PipeCommand iteration)::rest) -> 
             let _ = tg.Advance(lp.seg_size / (iterations - iteration) ) in
             lp.generate_points iterations rest tg (tg.Position::current) lines
       | (_::rest) -> lp.generate_points iterations rest tg current lines
       | [] -> current::lines                       
       


end