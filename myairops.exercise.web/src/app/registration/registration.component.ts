import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { fromEvent, merge, Observable } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { RegistrationService } from 'src/app/providers/services/registration.service';
import { HomePageMessages } from 'src/app/shared/form-validators-messages';
import { GenericValidator } from 'src/app/shared/generic-validator';
import { NgbDatepickerConfig, NgbCalendar, NgbDate, NgbDateStruct, NgbDateParserFormatter, NgbInputDatepicker } from '@ng-bootstrap/ng-bootstrap';
import swal from 'sweetalert2';


@Component({
    selector: 'app-home',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
    EmailPattern: string = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,10}$";
    @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
    displayMessage: { [key: string]: string } = {};
    public HomePageForm: FormGroup;
    public submitted = false;
    private genericValidator: GenericValidator;
    date = new Date();
    maxDate: NgbDateStruct;
    constructor(private _registrationService: RegistrationService,
        private fb: FormBuilder,
        private _route: Router) {
        this.genericValidator = new GenericValidator(HomePageMessages);
    }

    ngOnInit(): void {
        this.HomePageForm = this.fb.group({
            id: [null, Validators.required],
            userName: ['', [Validators.required, Validators.maxLength(255)]],
            emailId: ['', [Validators.required, Validators.email, Validators.maxLength(255), Validators.pattern(this.EmailPattern)]],
            dateOfBirth: [null, Validators.required]
        });
        this.maxDate=new NgbDate(this.date.getFullYear(), this.date.getMonth() + 1, this.date.getDate());
    }

    ngAfterViewInit(): void {
        // Watch for the blur event from any input element on the form.
        const controlBlurs: Observable<any>[] = this.formInputElements
            .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

        // Merge the blur event observable with the valueChanges observable
        merge(this.HomePageForm.valueChanges, ...controlBlurs).pipe(
            debounceTime(500)
        ).subscribe(value => {
            this.displayMessage = this.genericValidator.processMessages(this.HomePageForm, this.submitted);
        });
    }

    generateFormData() {
        if (this.HomePageForm.invalid) {
            this.submitted = true;
            this.displayMessage = this.genericValidator.processMessages(this.HomePageForm, this.submitted);
            return false;
        }

        let data = this.HomePageForm.value;

        const dob=new Date();
        dob.setDate(data.dateOfBirth.day);
        dob.setFullYear(data.dateOfBirth.year);
        dob.setMonth(data.dateOfBirth.month-1);

        data['dateOfBirth']=dob;


        this._registrationService.GenerateRegistrationData(data).subscribe(response => {
            swal('Success', 'Details added to text file', 'success');
            this.HomePageForm.reset();
        });

        this.submitted = false;
    }
}