import { Component } from '@angular/core';

interface ChatMessage {
  sender: string;
  content: string;
}

interface ChatbotResponse {
  pattern: RegExp;
  answer: string;
}

@Component({
  selector: 'app-servicioalcliente',
  templateUrl: './servicioalcliente.component.html',
  styleUrls: ['./servicioalcliente.component.css']
})
export class ServicioAlClienteComponent {
  chatMessages: ChatMessage[] = [];
  newMessage = '';

  chatbotResponses: ChatbotResponse[] = [
    {
      pattern: /tiempo de entrega/i,
      answer: 'El tiempo de entrega varía según la ubicación y el tipo de envío seleccionado. Por lo general, nuestros productos se entregan dentro de 5-7 días hábiles.'
    },
    {
      pattern: /seguimiento de mi pedido/i,
      answer: 'Puedes realizar un seguimiento de tu pedido iniciando sesión en tu cuenta y visitando la sección "Mis Pedidos". Allí encontrarás información actualizada sobre el estado de tu pedido.'
    },
    {
      pattern: /opciones de pago/i,
      answer: 'Aceptamos tarjetas de crédito, débito, PayPal y transferencias bancarias. Puedes seleccionar la opción de pago que prefieras durante el proceso de compra.'
    },
    {
      pattern: /devolver un producto/i,
      answer: 'Para devolver un producto, debes comunicarte con nuestro servicio de atención al cliente y proporcionar los detalles de tu pedido. Te brindaremos las instrucciones necesarias para realizar la devolución.'
    },
    {
      pattern: /cancelar un pedido/i,
      answer: 'Si deseas cancelar un pedido, comunícate con nuestro servicio de atención al cliente lo antes posible y proporciona los detalles de tu pedido. Nos aseguraremos de procesar tu solicitud de cancelación.'
    },
    {
      pattern: /número de seguimiento/i,
      answer: 'El número de seguimiento de tu pedido se proporciona una vez que se haya realizado el envío. Puedes encontrarlo en la sección "Mis Pedidos" o en el correo electrónico de confirmación de envío que te hemos enviado.'
    },
    {
      pattern: /cambiar la dirección de envío/i,
      answer: 'Si necesitas cambiar la dirección de envío de tu pedido, comunícate con nuestro servicio de atención al cliente lo antes posible. Haremos todo lo posible para actualizar la dirección antes de que se realice la entrega.'
    },
    {
      pattern: /¿Cuánto cuesta el envío?/i,
      answer: 'El costo de envío depende del destino y del tamaño del paquete. Durante el proceso de pago, se te mostrará el costo exacto del envío antes de confirmar tu pedido.'
    },
    {
      pattern: /problema con el pedido/i,
      answer: 'Lamentamos los inconvenientes. Por favor, contáctanos de inmediato con los detalles del problema. Nuestro equipo de servicio al cliente se encargará de resolverlo lo antes posible.'
    },
    {
      pattern: /cambiar la contraseña/i,
      answer: 'Para cambiar tu contraseña, inicia sesión en tu cuenta y ve a la sección de configuración de la cuenta. Allí encontrarás la opción para cambiar tu contraseña.'
    },
    {
      pattern: /tallas disponibles/i,
      answer: 'Las tallas disponibles varían según el producto. Puedes verificar la disponibilidad de tallas en la página de cada producto. Si la talla que buscas no está disponible, te recomendamos verificar nuevamente más adelante o explorar productos similares.'
    },
    {
      pattern: /costo de envío internacional/i,
      answer: 'El costo de envío internacional varía según el destino y el peso del paquete. Durante el proceso de pago, se te mostrará el costo exacto del envío antes de confirmar tu pedido.'
    },
    {
      pattern: /información de contacto/i,
      answer: 'Puedes encontrar nuestra información de contacto en la sección "Contáctanos" de nuestro sitio web. Allí encontrarás nuestros números de teléfono y dirección de correo electrónico para diferentes consultas y asistencia.'
    },
    {
      pattern: /productos en oferta/i,
      answer: 'Para ver los productos en oferta, visita nuestra sección de "Ofertas" en el sitio web. Allí encontrarás una amplia selección de productos con descuentos y promociones especiales.'
    },
    {
      pattern: /¿Qué hacer si no recibo el pedido?/i,
      answer: 'Si no has recibido tu pedido dentro del tiempo estimado de entrega, te recomendamos comunicarte con nuestro servicio de atención al cliente. Investigaremos la situación y te brindaremos una solución adecuada.'
    },
    {
      pattern: /¿Puedo cancelar una devolución?/i,
      answer: 'Si has solicitado una devolución y deseas cancelarla, comunícate con nuestro servicio de atención al cliente lo antes posible. Verificaremos el estado de la devolución y te brindaremos asistencia.'
    },
    {
      pattern: /¿Cómo puedo contactar al servicio al cliente?/i,
      answer: 'Puedes contactar a nuestro servicio al cliente llamando al número de teléfono proporcionado en nuestra página de contacto o enviándonos un correo electrónico. También puedes usar el chat en vivo en nuestro sitio web.'
    },
    {
      pattern: /reembolso del pedido cancelado/i,
      answer: 'Si has cancelado un pedido y deseas un reembolso, el reembolso se procesará según nuestra política de reembolso. Por lo general, el reembolso se acredita en la misma forma de pago utilizada durante la compra.'
    },
    {
      pattern: /¿Cómo puedo editar mi dirección de envío?/i,
      answer: 'Si necesitas editar tu dirección de envío, puedes hacerlo iniciando sesión en tu cuenta y yendo a la sección de configuración de la cuenta. Allí encontrarás la opción para editar tu dirección de envío.'
    },
    {
      pattern: /información sobre impuestos/i,
      answer: 'La información sobre impuestos varía según la ubicación y las regulaciones fiscales locales. Durante el proceso de pago, se te mostrará cualquier impuesto aplicable antes de confirmar tu pedido.'
    },

  ];

  frequentlyAskedQuestions = [
    {
      question: '¿Cuál es el tiempo de entrega?',
      answer: 'El tiempo de entrega varía según la ubicación y el tipo de envío seleccionado. Por lo general, nuestros productos se entregan dentro de 5-7 días hábiles.'
    },
    {
      question: '¿Cómo puedo realizar un seguimiento de mi pedido?',
      answer: 'Puedes realizar un seguimiento de tu pedido iniciando sesión en tu cuenta y visitando la sección "Mis Pedidos". Allí encontrarás información actualizada sobre el estado de tu pedido.'
    },

    // Agrega más preguntas frecuentes aquí
  ];

  categories = ['Envío', 'Devoluciones', 'Pagos', 'Cuentas'];

  sendMessage() {
    if (this.newMessage.trim() !== '') {
      this.chatMessages.push({ sender: 'Usuario', content: this.newMessage });
      this.processMessage(this.newMessage);
      this.newMessage = '';
    }
  }

  processMessage(message: string) {
    const question = message.trim();

    let matchedResponse = null;
    for (const response of this.chatbotResponses) {
      if (response.pattern.test(question)) {
        matchedResponse = response;
        break;
      }
    }

    if (matchedResponse) {
      this.chatMessages.push({ sender: 'Chatbot', content: matchedResponse.answer });
    } else {
      this.chatMessages.push({ sender: 'Chatbot', content: 'Lo siento, no entiendo tu pregunta. Por favor, intenta con otra.' });
    }
  }

  handleCategoryClick(category: string) {
    console.log('Categoría seleccionada:', category);
    // Aquí puedes agregar la lógica para manejar la selección de categoría
  }

  handleFAQClick(question: string) {
    console.log('Pregunta seleccionada:', question);
    // Aquí puedes agregar la lógica para manejar la selección de una pregunta frecuente
  }
}
