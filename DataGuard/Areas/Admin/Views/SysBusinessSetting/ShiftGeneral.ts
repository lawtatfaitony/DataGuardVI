module Time {
    export class Tests {
        element: HTMLElement;
        span: HTMLElement;
        timer: number;
        constructor(e: HTMLElement) {  
            this.element = e;
            this.element.innerHTML = "Now Time is: ";
            this.span = document.createElement('span');
            this.element.appendChild(this.span);
            this.span.innerHTML = new Date().toTimeString();
        }
        start() {
            this.timer = setInterval(() => this.span.innerHTML = new Date().toTimeString(), 500);
        }
        stop() {
            clearTimeout(this.timer);
        }
    }
}