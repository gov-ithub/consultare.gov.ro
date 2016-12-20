import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'htmlContent'
})
// The work of the pipe is handled in the tranform method with our pipe's class
export class HtmlContentPipe implements PipeTransform {
        
    constructor() {}

  transform(value: string, htmlContentList: any) {
    return htmlContentList[value] ? htmlContentList[value] : value;

  }
}
