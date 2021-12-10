﻿using Aplication;
using Domain.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidacionDeLoginUsuarioInexistente()
        {
            UsuarioService usuario = new UsuarioService();
            Usuario user = new Usuario();
            string correo = "correomisterioso1";
            string contra = "contrasena";
            object[] login = usuario.IniciarUsuario(correo, contra);
            Assert.IsNull(login);
        }
        [TestMethod]
        public void ValidacionDeLoginUsuario()
        {
            UsuarioService usuario = new UsuarioService();
            Usuario user = new Usuario();
            string correo = "Admin";
            string contra = "123qweu0";
            object[] login = usuario.IniciarUsuario(correo, contra);
            Assert.IsNotNull(login);
        }
        [TestMethod]
        public void ComprobarIncorrectaLonguitudDNI()//TDD
        {
            UsuarioService user = new UsuarioService();
            string dni = "123456789";
            string Nombre = "nombre1";
            string Apellido = "apellidos1";
            string Direccion = "direccion1";
            string Email = "email1";
            string Telefono = "telefono1";
            string Contrasenia = "";

            int x = user.RegistrarUsuario(dni, Nombre, Apellido, Direccion, Email, Telefono, Contrasenia);
            Assert.AreEqual(x, -1);
        }

        [TestMethod]
        public void Activar_Empleado()
        {
            EmpleadoService employee = new EmpleadoService();
            Empleado person = new Empleado();
            person.ID_EMPLEADO = 25;
            bool correcto = employee.ActivarEmpleado(person.ID_EMPLEADO);
            Assert.AreEqual(true, correcto);
        }


        [TestMethod]
        public void Desactivar_Empleado()
        {
            EmpleadoService employee = new EmpleadoService();
            Empleado person = new Empleado();
            person.ID_EMPLEADO = 25;
            bool correcto = employee.DesactivarEmpleado(person.ID_EMPLEADO);
            Assert.AreEqual(true, correcto);
        }
        [TestMethod]
        public void Actualizar_Contacto_al_Cliente()
        {
            ClienteService client = new ClienteService();
            Cliente person = new Cliente();
            person.ID_Cliente = 10;
            bool correcto = client.ActualizarCliente(person.ID_Cliente, "emael", "telefono");
            Assert.AreEqual(true, correcto);
        }

        [TestMethod]
        public void Actualizar_Contacto_al_Cliente_ERROR()
        {
            ClienteService client = new ClienteService();
            Cliente person = new Cliente();
            person.ID_Cliente = 10000;
            bool correcto = client.ActualizarCliente(person.ID_Cliente, " ", "telefono");
            Assert.AreEqual(false, correcto);
        }

        [TestMethod]
        public void Registrar_Cliente()
        {
            ClienteService customer = new ClienteService();
            bool resultado = customer.RegistrarCliente("12345", "NOMBRE1", "APELLIDO1", "Calle 123123", "email", "telefono", "1111");
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void Registrar_Cliente_DNI_Incorrecto()
        {
            ClienteService customer = new ClienteService();
            bool resultado = customer.RegistrarCliente("123456789", "NOMBRE1", "APELLIDO1", "Av. Calle 123123", "email1", "telefono1", "");
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void Registrar_Empleado()
        {
            EmpleadoService employee = new EmpleadoService();
            bool resultado = employee.RegistrarEmpleado("Secretario", "Administracion", "47383067", "PRUEBA03", "XD", "Av. XD", "emailNEW", "telefonoN", "3333");
            Assert.IsTrue(resultado);
        }

        
        [TestMethod]
        public void Registrar_Empleado_DNI_Incorrecto()//TDD
        {
            EmpleadoService employee = new EmpleadoService();
            Empleado person = new Empleado();

            bool resultado = employee.RegistrarEmpleado("Secretario", "Administracion", "123456789", "PRUEBA03", "XD", "Av. XD", "emailNEW", "telefonoN", "");
            Assert.IsFalse(resultado);
        }
        [TestMethod]
        public void Buscar_Empleado()
        {
            EmpleadoService employee = new EmpleadoService();
            List<Empleado> busqueda = employee.BuscarEmpleado("1");
            Assert.IsNotNull(busqueda);
        }
        [TestMethod]
        public void Buscar_Empleado_ERROR()
        {
            EmpleadoService employee = new EmpleadoService();
            List<Empleado> busqueda = employee.BuscarEmpleado(null);
            Assert.IsNull(busqueda);
        }
        [TestMethod]
        public void Buscar_Cliente()
        {
            ClienteService employee = new ClienteService();
            List<Cliente> busqueda = employee.BuscarCliente("");
            Assert.IsNotNull(busqueda);
        }
        [TestMethod]
        public void Buscar_Cliente_ERROR()
        {
            ClienteService employee = new ClienteService();
            List<Cliente> busqueda = employee.BuscarCliente(null);
            Assert.IsNull(busqueda);
        }

        [TestMethod]
        public void Registrar_Pedido()
        {
            PedidoService obj = new PedidoService();

            int resultado = obj.RegistrarPedido(1, 1, 1, 1000.00);
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void Listar_Pedidos()
        {
            PedidoService obj = new PedidoService();

            List<Pedido> resultado = obj.ListarPedidos("97875450");
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public void Buscar_Estado_Pedido()
        {
            PedidoService obj = new PedidoService();

            bool resultado = obj.VerificarEstadoPedido(1);
            Assert.IsFalse(resultado);
        }
        [TestMethod]
        public void Buscar_Detalle_Pedido()
        {
            DetallePedidoService obj = new DetallePedidoService();

            List<DetallePedido> detalles = obj.BuscarDetallePedido(1);
            Assert.IsNotNull(detalles);
        }
        [TestMethod]
        public void Buscar_Material()
        {
            MaterialService obj = new MaterialService();

            List<Material> detalles = obj.BuscarMaterial("Pomello");
            Assert.IsNotNull(detalles);
        }

        [TestMethod]
        public void Registrar_Material()
        {
            MaterialService obj = new MaterialService();

            bool resultado = obj.RegistrarMaterial("Pomello","des",12,"kg",500,0.5);
            Assert.IsTrue(resultado);
        }

     

        [TestMethod]
        public void Actualizar_Material()
        {
            MaterialService obj = new MaterialService();

            bool resultado = obj.ActualizarMaterial(500, 1);
            Assert.IsTrue(resultado);
        }
        [TestMethod]
        public void Actualizar_Cliente()
        {
            ClienteService cliente = new ClienteService();
            bool resultado = cliente.ActualizarCliente(1,"gmail","nuevo");
            Assert.IsTrue(resultado);
        }

        
    }
}
