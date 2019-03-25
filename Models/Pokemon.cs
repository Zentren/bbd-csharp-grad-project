public class Pokemon{
 private int number,hp;
 private string name, description,status;
 private string[] type=new string[2],moveset=new string[4];
 private double weight,height;
 private  Pokemon preEvolve=null, Evolve=null;

 private Image image = null;

 private bool finalForm=false,firstForm=false;
 
 public Pokemon(string name){
     this.name=name;
     //get imfo from database
 }

public Pokemon(int number){
     this.number=number;
     //get imfo from database
 }
 public void setFinalForm(bool finalForm){
     this.finalForm=finalForm;
 }
 public bool getFinalForm(){
     return this.finalForm;
 }

 public void setFirstForm(bool firstForm){
     this.firstForm = firstForm;
 }

 public bool getFirstForm(){
     return this.firstForm;
 }
 public void setNumber(int number){
     this.number = number;
 }
 
 public int getNumber(){
     return this.number;
 }

 public void setHp(int hp){
     this.hp=hp;
 }

 public int getHp(){
     return this.hp;
 }

 public void setName(string name){
     this.name=name;
 }

 public string getName(){
     return this.name;
 }

 public void setDescription(string description){
     this.description = description;
 }

 public string getDescription(){
     return this.description;
 }

 public void setStatus(string status){
     this.status = status;
 }

 public string getStatus(){
     return this.status;
 }

 public void setTypes(string type1,string type2){
     this.type[0]=type1;
     if(!(type2==null || type2==""))
        this.type[1]=type2;
     else this.type[1] = null;   
 }

 public string[] getTypes(){
     return this.getTypes;
 }

 public void setMoves(string move1,string move2,string move3,string move4){
     this.moveset[0]= move1;
     if(!(move2==null || move2==""))
        this.moveset[1]=move2;
     else this.moveset[1] = null;
     if(!(move3==null || move3==""))
        this.moveset[2]=move3;
     else this.moveset[2] = null;
     if(!(move4==null || move4==""))
        this.moveset[3]=move4;
     else this.moveset[3] = null;
 }
 public string[] getMoves(){
     return this.moveset;
 }
 public void setWeight(double weight){
     this.weight=weight;
 }
 public double getWeight(){
     return this.weight;
 }
 public void setHeight(double height){
     this.height=height;
 }
 public double getHeight(){
     return this.height;
 }
 public void setImage(string url){
     this.image=Image.FromFile(url);
 }
 public Image getImage(){
     return this.image;
 }

 public string[] weaknesses(){return null;}
 public string[] strengths(){return null;}

 public void evolve(){
     if(this.getFinalForm()||this.number+1>151){
      this.Evolve =  null;
      return;
     }
     this.Evolve = new Pokemon(this.number+1);
 }

 public void devolve(){
     if(this.number-1<1|| this.getFirstForm()){
         this.preEvolve=null;
         return;
     }    
     this.preEvolve = new Pokemon(this.number-1);
 }
}