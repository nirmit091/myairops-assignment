// Provide all common set of validation messages here
export const HomePageMessages = {
    id: {
        required: 'Please enter Id'
    },
    userName: {
        required: 'Please enter user name',
        maxlength: 'Please enter up to 255 characters'
    },
    emailId: {
        required: 'Please enter email address',
        pattern: 'Please enter a valid email address',
        maxlength: 'Please enter up to 255 characters'
    },
    dateOfBirth: {
        required: 'Please select Date of Birth'
    }
}
