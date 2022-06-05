import { FormGroup } from "@angular/forms";

export class GenericValidator {
    // By default the defined set of validation messages is pass but a custom message when the class is called can also be passed
    constructor(private validationMessages: { [key: string]: { [key: string]: string } }) { }

    // this will process each formcontrol in the form group
    // and then return the error message to display
    // the return value will be in this format `formControlName: 'error message'`;
    processMessages(container: FormGroup, isSubmit: boolean): { [key: string]: string } {
        const messages = {};
        // loop through all the formControls
        for (const controlKey in container.controls) {
            if (container.controls.hasOwnProperty(controlKey)) {
                // get the properties of each formControl
                const controlProperty = container.controls[controlKey];
                // If it is a FormGroup, process its child controls.
                if (controlProperty instanceof FormGroup) {
                    const childMessages = this.processMessages(controlProperty, isSubmit);
                    Object.assign(messages, childMessages);
                } else {
                    // Only validate if there are validation messages for the control
                    if (this.validationMessages[controlKey]) {
                        messages[controlKey] = '';
                        if ((controlProperty.dirty || controlProperty.touched || isSubmit) && controlProperty.errors) {
                            // loop through the object of errors
                            Object.keys(controlProperty.errors).map(messageKey => {
                                if (this.validationMessages[controlKey][messageKey]) {
                                    if (messageKey == 'cannotContainSpace') {
                                        if (!controlProperty.errors['required']) {
                                            return messages[controlKey] += this.validationMessages[controlKey][messageKey] + ' ';
                                        }
                                    } else {
                                        return messages[controlKey] += this.validationMessages[controlKey][messageKey] + ' ';
                                    }
                                }
                            });
                        }
                    }
                }
            }
        }
        return messages;
    }
}
