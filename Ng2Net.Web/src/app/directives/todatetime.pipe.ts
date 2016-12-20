import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'toDateTime'
})
// The work of the pipe is handled in the tranform method with our pipe's class
export class ToDateTimePipe implements PipeTransform {
        
    constructor() {}

  transform(value: string) {
    return value && value.toLowerCase().indexOf('invalid')<0 ? new Date(value) : undefined;
  }
}
