import React, { useState, useEffect } from "react";
import { Grid, TextField, withStyles, FormControl, Select, MenuItem, Button, FormHelperText } from "@material-ui/core";
import useForm from "../useForm";
import { connect } from "react-redux";
import * as actions from "../../actions/organization/module";
import { useToasts } from "react-toast-notifications";

const mapStateToProps = (state) => ({
  moduleList: state.modules.list,
});

const mapActionToProps = {
  create: actions.create,
  update: actions.update,
};

const styles = (theme) => ({
  root: {
    "& .MuiTextField-root": {
      margin: theme.spacing(1),
      minWidth: 230,
    },
  },
  formControl: {
    margin: theme.spacing(1),
    minWidth: 230,
  },
  smMargin: {
    margin: theme.spacing(1),
  },
});

const initialFieldValues = {
  moduleName: "",
};

const ModuleForm = ({ classes, ...props }) => {
  //toast msg.
  const { addToast } = useToasts();

  //validate()
  //validate({fullName:'jenny'})
  const validate = (fieldValues = values) => {
    let temp = { ...errors };
    if ("moduleName" in fieldValues) temp.moduleName = fieldValues.moduleName ? "" : "This field is required.";

    setErrors({
      ...temp,
    });

    if (fieldValues == values) {
      return Object.values(temp).every((x) => x == "");
    }
  };

  const { values, setValues, errors, setErrors, handleInputChange, resetForm } = useForm(
    initialFieldValues,
    validate,
    props.setCurrentId
  );

  const handleSubmit = (e) => {
    e.preventDefault();
    if (validate()) {
      const onSuccess = () => {
        resetForm();
        addToast("Submitted successfully", { appearance: "success" });
      };

      if (props.currentId == 0 || props.currentId == undefined) props.create(values, onSuccess);
      else props.update(props.currentId, values, onSuccess);
    }
  };

  useEffect(() => {
    if (props.currentId != 0) {
      setValues({
        ...props.moduleList.find((x) => x.ids == props.currentId),
      });
      setErrors({});
    }
  }, [props.currentId]);

  return (
    <form autoComplete="off" noValidate className={classes.root} onSubmit={handleSubmit}>
      <Grid container>
        <Grid item xs={12}>
          <TextField
            name="moduleName"
            variant="outlined"
            label="Module Name"
            value={values.moduleName}
            onChange={handleInputChange}
            {...(errors.ModuleName && { error: true, helperText: errors.ModuleName })}
          />
        </Grid>

        <Grid item xs={12}>
          <div>
            <Button variant="contained" color="primary" type="submit" className={classes.smMargin}>
              Submit
            </Button>
            <Button variant="contained" className={classes.smMargin} onClick={resetForm}>
              Reset
            </Button>
          </div>
        </Grid>
      </Grid>
    </form>
  );
};

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(ModuleForm));
