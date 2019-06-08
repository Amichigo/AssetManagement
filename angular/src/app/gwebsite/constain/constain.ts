export abstract class Constain{
    public static showConsoleLog=true;
    public static status:Status[]=[
        {id:1,Name:"waiting"},
        {id:2,Name:"uncheck"},
        {id:3,Name:"checked"}
    ]
 


}
export class Status
{
    id: number;
    Name:string;
}

