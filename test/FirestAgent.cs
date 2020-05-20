

using System;
using MyBehavior;

public class FirstAgent : Agent{

    private int judg = 1;

    public void SayHello(){
        Console.WriteLine("Hello World!");
    }
    
    public bool CanEnterAction(){
        Console.WriteLine("CanEnterAction!");
        if (judg == 1){
            return false;
        }
        return true;
    }
}