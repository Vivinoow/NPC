using System.Security.Cryptography; 
const int CAÇANDO=1; 
const int ABATENDO=6; 
const int FUGINDO=8; 
const int MORTO=10; 
const double Fps=4; 

Console.WriteLine("--- NPC ---\n"); 

int estado=CAÇANDO; 
int estadoAnterior=CAÇANDO; 
string descricaoEstado=""; 
string descricaoEstadoAnterior=""; 
bool AdversárioProximo=false; 
bool Baleado=false; 
bool eliminado=false; 
int transicoes=0; 

while(estado!=MORTO) 
{estadoAnterior=estado;transicoes++; 

switch(estado) 
{case CAÇANDO: 
if(RandomNumberGenerator.GetInt32(0,4)==0) Baleado=false; 
if(RandomNumberGenerator.GetInt32(0,6)==0) AdversárioProximo=true;break;

case ABATENDO: 
if(RandomNumberGenerator.GetInt32(0,2)==0) 
{Baleado=true; 
if(RandomNumberGenerator.GetInt32(0,4)==0)eliminado=true;} 
if (RandomNumberGenerator.GetInt32(0,6)==0)AdversárioProximo=false; 
break; 

case FUGINDO: 
if(RandomNumberGenerator.GetInt32(0,6)==0) eliminado=true; 
if(RandomNumberGenerator.GetInt32(0,6)==0) Baleado=false; 
if(RandomNumberGenerator.GetInt32(0,6)==0) AdversárioProximo=false; 
break;} 

if (eliminado) 
estado=MORTO; 
else if(estado==CAÇANDO&&!Baleado &&AdversárioProximo) 
estado=ABATENDO; 
else if(estado==ABATENDO) 
{if(!AdversárioProximo) 
estado=CAÇANDO; 
else if(Baleado) 
estado=FUGINDO;} 
else if(estado==FUGINDO&&!Baleado) 
estado=CAÇANDO; 

switch(estadoAnterior) 
{case CAÇANDO:descricaoEstadoAnterior="Caçando";break; 
case ABATENDO:descricaoEstadoAnterior="Abatendo";break; 
case FUGINDO:descricaoEstadoAnterior="Fugindo";break; 
case MORTO:descricaoEstadoAnterior="Morto";break;} 

switch(estado) 
{case CAÇANDO:descricaoEstado="Caçando";break; 
case ABATENDO:descricaoEstado ="Abatendo";break; 
case FUGINDO:descricaoEstado ="Fugindo";break; 
case MORTO:descricaoEstado ="Morto";break;} 

Console.WriteLine($"{transicoes,4}{descricaoEstadoAnterior,8}:Baleado={(Baleado?"S":"N")},AdversárioProximo={(AdversárioProximo ?"S":"N")},Eliminado={(eliminado ?"S":"N")}=>{descricaoEstado}"); 
Thread.Sleep(Convert.ToInt32(1200/Fps));} 
Console.WriteLine($"\n NPC sobreviveu por {transicoes-2} transições."); 
