package main

import "fmt"
// import r "math/rand"

func main() {
//	numero := r.Int()
	bigNumero := 10000000000000
	fmt.Println("Numero: ", bigNumero)
	fmt.Println("Endereco memoria: ", &bigNumero)
}