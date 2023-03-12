import React from 'react';
import Box from '@mui/material/Box';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Modal from '@mui/material/Modal';
import { useDispatch, useSelector } from 'react-redux';
import { onPostData } from '../../action';
import TextField from '@mui/material/TextField';

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 600,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
};

const AddCourseModa = () => {
  const dispatch = useDispatch();
  const [open, setOpen] = React.useState(false);
  const handleOpen = () => setOpen(true);
  const handleClose = () => setOpen(false);

  const [CourseName, setCourseName] = React.useState('');
  const [Description, setDescription] = React.useState('');
  const [DurationDays, setDurationDays] = React.useState('');
  const [StartDate, setStartDate] = React.useState('');

  const handleChange = (e) => {
    if (e.target.id === "CourseName") {
      validateCourseName(e.target.value);
    }
    if (e.target.id === "Description") {
      validateDescription(e.target.value);
    }
    if (e.target.id === "DurationDays") {
      validateDurationDays(e.target.value);
    }
    if (e.target.id === "StartDate") {
      validateStartDate(e.target.value);
    }
  }
  const validateCourseName = (CourseName) => {
    setCourseName(CourseName);
  }
  const validateDescription = (Description) => {
    setDescription(Description);
  }

  const validateDurationDays = (DurationDays) => {
    setDurationDays(DurationDays);
  }

  const validateStartDate = (StartDate) => {
    setStartDate(StartDate);
  }


  const handleSubmit = (e) => {
    e.preventDefault();
    let data = {
      CourseName: CourseName,
      Description: Description,
      DurationDays: DurationDays,
      StartDate: StartDate
    }
    dispatch(onPostData(data));
    setOpen(false);
  }

  return (
    <>
      <Button variant="contained" onClick={handleOpen}>Add</Button>
      <br />
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Typography id="modal-modal-title" variant="h6" component="h2">
            Course Form
          </Typography>
          <Typography id="modal-modal-description" sx={{ mt: 2 }}  component={'span'}>
            <form>
              <div className='row'>
                <div className='col-md-6' style={{marginBottom: '20px'}}>
                  <TextField
                    required
                    id="CourseName"
                    label="Course Name"
                    onChange={handleChange}
                    style={{width: "100%"}}
                  />
                </div>
                <div className='col-md-6'>
                  <TextField
                    required
                    id="Description"
                    label="Description"
                    onChange={handleChange}
                    style={{width: "100%"}}
                  />
                </div>
                <div className='col-md-6'>
                  <TextField
                    required
                    id="DurationDays"
                    label="Duration"
                    onChange={handleChange}
                    style={{width: "100%"}}
                  />
                </div>
                <div className='col-md-6' >
                  <TextField
                    required
                    id="StartDate"
                    label="Start Date"
                    onChange={handleChange}
                    type="date"
                    InputLabelProps={{
                      shrink: true,
                    }}
                    style={{width: "100%"}}
                  />
                </div>
              </div>
              <br />
              <Button variant="contained" onClick={handleSubmit} style={{float:'right'}}>Submit</Button>
            </form>
          </Typography>
        </Box>
      </Modal>
    </>
  );
};

export default AddCourseModa;