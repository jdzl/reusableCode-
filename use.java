import android.view.inputmethod.*;


imageButtonBuscar.setOnClickListener(new OnClickListener() {

    public void onClick(View v) {
        InputMethodManager inputMethodManager = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);

        inputMethodManager.hideSoftInputFromWindow(editTextBuscar.getWindowToken(), 0);
    }
});
