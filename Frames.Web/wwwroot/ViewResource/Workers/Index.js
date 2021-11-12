let _$modal = $('#addNewWorkerModal'),
    _$form = _$modal.find('form'),
    _$table = $('#datatable'),
    _$createButton = $('#openCreateWorkerModal'),
    _$nameInput = $('#newWorkerNameInput'),
    _$idInput = $('#newWorkerId'),
    _$nameInputInvalidFeedback = $('#newWorkerNameInvalidFeedback');

let _$workerTable = _$table.DataTable({
    processing: true, // for show progress bar
    serverSide: true, // for process server side
    filter: true, // this is for disable filter (search box)
    orderMulti: false, // for disable multiple column at once
    ajax: {
        url: "/Workers/GetAllWorkers",
        type: "post",
        datatype: "json"
    },
    //"columnDefs": [{
    //    "targets": [0],
    //    "searchable": false,
    //    "sortable": false
    //}],
    columns: [
        {
            data: "id",
            name: "ID",
            autoWidth: true,
            defaultContent: '',
            searchable: false,
            sortable: false
        },
        {
            data: "name",
            name: "Name",
            autoWidth: true,
            defaultContent: ''
        },
        {
            sortable: false,
            searchable: false,
            autoWidth: false,
            defaultContent: '',
            render: (data, type, row, meta) => (
                `<button type="button" class="btn btn-sm btn-secondary edit-worker" data-worker-id="${row.id}">
                        <i class="fas fa-pencil-alt"></i> Edit
                     </button>
                     <button type="button" class="btn btn-sm btn-danger delete-worker" data-worker-id="${row.id}" data-worker-name="${row.name}">
                        <i class="fas fa-trash"></i> Delete
                     </button>`
            )
        }
    ]
});

_$createButton.on('click', (e) => {
    e.preventDefault();
    _$idInput.val(0)
    _$nameInput.val('');
    _$nameInput.removeClass('is-valid');
    _$nameInput.removeClass('is-invalid');
    _$nameInputInvalidFeedback.html('');
    _$modal.modal('show');
})

_$nameInput.on('blur', e => checkNameExist(e))

_$form.find('.save-button').on('click', async (e) => {
    e.preventDefault();
    const updating = _$idInput.val() > 0 ? true : false;
    const notOk = await checkNameExist();
    if (notOk) return;

    const workerDto = {
        Id: _$idInput.val(),
        Name: _$nameInput.val()
    }
    debugger;
    let response;
    try {
        response = await postData('workers/CreateOrUpdateWorker', workerDto)
    } catch (err) {
        alert(err)
        return;
    }

    if (response.id) {
        if (!updating) {
            alert('created')
        } else {
            alert('updated')
        }
    }
    _$workerTable.ajax.reload()
    _$modal.modal('hide')
})

async function postData(url = "", data = {}) {
    const response = await fetch(url, {
        method: 'POST',
        mode: 'same-origin',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })

    return response.json();
}

const checkNameExist = async () => {
    let name = _$nameInput.val();

    if (!name) {
        _$nameInput.addClass('is-invalid');
        _$nameInputInvalidFeedback.html(`Name cannot be empty`);
        return true;
    }

    let isExistFetch = await fetch(`/Workers/IsWorkersNameTaken?name=${name}`);
    let isExist = await isExistFetch.json();

    if (isExist) {
        _$nameInput.removeClass('is-valid');
        _$nameInput.addClass('is-invalid');
        _$nameInputInvalidFeedback.html(`${name} is taken`);
        return true;
    }
    else {
        _$nameInput.removeClass('is-invalid');
        _$nameInput.addClass('is-valid');
        _$nameInputInvalidFeedback.html('');
        return false;
    }
}

$(document).on('click', '.edit-worker', async function (e) {
    e.preventDefault();
    const dataId = $(this).attr('data-worker-id');
    debugger;
    try {
        const fetchWorkerRecord = await fetch(`/workers/GetOneWorkerDetails?workerId=${dataId}`)
        const workerRecord = await fetchWorkerRecord.json()

        _$nameInput.removeClass('is-valid');
        _$nameInput.removeClass('is-invalid');
        _$nameInputInvalidFeedback.html('');
        _$idInput.val(workerRecord.id)
        _$nameInput.val(workerRecord.name)
        _$modal.modal('show');
    } catch (err) {
        alert(err)
    }
})

$(document).on('click', '.delete-worker', async function (e) {
    const dataId = $(this).attr('data-worker-id');
    const dataName = $(this).attr('data-worker-name');
    e.preventDefault();

    debugger;
    const isConfirmed = confirm(`Are you sure, you want to delete worker ${dataName}`)
    if (!isConfirmed) {
        return;
    }

    try {
        await fetch(`/workers/DeleteWorker?workerId=${dataId}`)
        alert(`${dataName} is deleted`)
    } catch (err) {
        alert(err)
        return;
    }

    _$workerTable.ajax.reload()
})
