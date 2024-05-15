namespace Auto{
    class Automovil {
        private int modelo;
        private string marca;
        private bool disponible;
        private double precio;
        private double tipoCambioDolar;
        //Descuento en %
        private double descuentoAplicado;
    
        public Automovil() {
            modelo = 2019;
            precio = 10000.00d;
            marca = "";
            disponible = false;
            tipoCambioDolar = 7.5d;
            descuentoAplicado = 0.00d;
        }
    
        public void DefinirModelo(int unModelo) {
            this.modelo = unModelo;
        }
    
        public void DefinirPrecio(double unPrecio) {
            this.precio = unPrecio;
        }
    
        public void DefinirMarca(string unaMarca) {
            this.marca = unaMarca;
        }
    
        public void DefinirTipoCambio(double unTipoCambio) {
            this.tipoCambioDolar = unTipoCambio;
        }
    
        public void CambiarDisponibilidad() {
            this.disponible = !this.disponible;
        }
    
        public string MostrarDisponibilidad() {
            if(disponible) {
                return "Disponible";
            }
            else {
                return "No se encuentra disponible actualmente";
            }
        }
    
        public string MostrarInformacion() {
            double precioLocal = this.precio;
            double precioExtranjero = precioLocal / this.tipoCambioDolar;
            string ret = $"Marca: {this.marca}\nModelo: {this.modelo}\nPrecio de venta: Q{precioLocal}\nPrecio en dólares: ${precioExtranjero}\nDisponibilidad: {this.MostrarDisponibilidad()}\n";
            return ret;
        }
    
        public void AplicarDescuento(double miDescuento) {
            this.descuentoAplicado = miDescuento;
            DefinirPrecio(this.precio - (this.precio * this.descuentoAplicado/100)); 
        }
    }
}
    