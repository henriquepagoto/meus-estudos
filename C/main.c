#include "stdio.h"
//#include "conio.h"

int  i, j, bobinajumbo, quantidadejumbo, npedido;
float peso, diametro, comprimento, usadojumbo, comprimentototal=0;
int comprimentojumbo=2450, pesojumbo=5000, diametrojumbo=1600; 


float pesopormetro=(125.0/98.0); // O peso por metro foi calculado pelos dados da bobina jumbo.

// pesopormetro = pesojumbo / ( comprimentojumbo * ( diametrojumbo / 1000 ) ).

// Para o compilar entender que a divisao resulta um float os numeros que estam sendo divididos tem que ter .0

float pedido[3][50] = {0};

int sequenciadecorte[20][50]={0};
float sobrajumbo[20];

main(){
       int lerdados(int pedidos);
       int imprimirdados(int pedidos);
       int pedidos;
       int quantasbobinasjumbos(int pedidos);
       int comocortar(int bobinajumbo, int pedidos);
       
       printf("Quantos pedidos? \n");
       scanf("%d", &pedidos);
       
       if(pedidos>50){
            printf("Quantidade invalida, usar menos de 50 pedidos");
       }
       else{
            lerdados(pedidos);
            
            imprimirdados(pedidos);
	    
	    quantidadejumbo = quantasbobinasjumbos(pedidos);
	    
	    comocortar(quantidadejumbo, pedidos);
            
            
       }
       
       printf("\n\n");
       
     // getch(); 
       
}       

int lerdados(int pedidos){
      
      for(i=0; i<pedidos; i++){
	
	  pedido[0][i] = i;
	  
               printf("\nDigite o diametro do pedido %d: ", i);
               scanf("%f", &pedido[1][i]);
               
               printf("\nDigite o comprimento do pedido %d: ", i);
               scanf("%f", &pedido[2][i]);
	       
	       if (pedido[2][i] > comprimentojumbo){
		 printf("\n\nComprimento muito grande");
	       
	       //A formula eh peso = comprimento * (diametro / 1000) * pesopormetro
	       
	       pedido[3][i]= pedido[2][i] * (pedido[1][i] / 1000 ) * pesopormetro;
               
               printf("\nO peso do pedido %d eh %.2f ", i, pedido[3][i]);

	      }
      
      
      }
      
}

int imprimirdados(int pedidos){
  
      
      printf("\n\nPEDIDOS         DIAMETRO           COMPRIMENTO            PESO");
      
      for(i=0; i<pedidos; i++){

             printf("\n   %d           %.2f             %.2f                %.2f ", i, pedido[1][i], pedido[2][i], pedido[3][i]);              
               
               
      }
      
      
      
}      

int quantasbobinasjumbos(int pedidos){
  
  for(i=0; i<pedidos; i++){
    comprimentototal = comprimentototal + pedido[2][i];
  }
  return comprimentototal / comprimentojumbo + 1;
}

int comocortar(int bobinajumbo, int pedidos){

  // Para cortar vamos verificar pedido por pedido com o que sobrou da jumbo
  
  for(i=0; i<bobinajumbo; i++){
    sobrajumbo[i] = 2450.0;
  }
  for (j=0; j<bobinajumbo; j++){
    
    printf("\n\nBonina Jumbo: n%d ", j);
    
    for(i=0;i<pedidos; i++){
      if(pedido[2][i]< sobrajumbo[j] && encontrarpedidosequencia(pedidos, bobinajumbo, i)){
	sobrajumbo[j] = sobrajumbo[j] - pedido[2][i];
	sequenciadecorte[j][i]= pedido[0][i];
	printf("\nCortar pedaco de %.2f da bobina junbo %d para atender o pedido %d", pedido[2][i], j, i);
    
      }
    }
  }
  
  for(i=0; i<bobinajumbo; i++){
    printf("\nSobrou %.2f da bobina jumbo %d. ", sobrajumbo[i], i);
  }
  
}

int encontrarpedidosequencia(int pedidos, int bobinajumbo, int npedido){
   for (j=0; j<bobinajumbo; j++){
     
     for(i=0;i<pedidos; i++){
       
       if ( sequenciadecorte[j][i] == npedido){
	 
	 return 1;
       }
       else{
	 return 0;
       }
       
       
     }
  }
  
}
    