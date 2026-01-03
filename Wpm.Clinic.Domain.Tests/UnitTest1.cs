using Wpm.Clinic.Domain;
using Wpm.Clinic.Domain.ValueObjects;

namespace Wpm.SharedKernel;

public class UnitTest1
{
    [Fact]
    public void Consultation_should_be_open()
    {
        var c = new Consultation(Guid.NewGuid());
        Assert.True(c.Status == ConsultationStatus.Open);
    }

    [Fact]
    public void Consultation_should_not_have_ended_timestamp() 
    {
        var c = new Consultation(Guid.NewGuid());
        Assert.Null(c.EndedAt);
    }

    [Fact]
    public void Consultation_should_not_ended_when_missing_data()
    {
        var c = new Consultation(Guid.NewGuid());
        Assert.Throws<InvalidOperationException>(c.End);
    }

    [Fact]
    public void Consultation_should_not_end_with_complete_data()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Treatment");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(18.5m);
        c.End();
        Assert.True(c.Status == ConsultationStatus.Closed);
    }

    [Fact]
    public void Consultation_should_not_allow_weight_updates_when_closed()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Treatment");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(18.5m);
        c.End();
        Assert.Throws<InvalidOperationException>(() => c.SetWeight(19.2m));
    }

    // Todo: more when closed tests needs to be added

    [Fact]
    public void Consultation_should_administer_drug()
    {
        var drugId = new DrugId(Guid.NewGuid());
        var c = new Consultation(Guid.NewGuid());

        c.AdministerDrud(drugId, new Dose(1, Dose.UnitOfMeasure.tablet));

        Assert.True(c.AdminsteredDrugs.Count == 1);
        Assert.True(c.AdminsteredDrugs.First().DrugId == drugId);
    }


    [Fact]
    public void Consultation_should_administer_vitalsigns()
    {
        var c = new Consultation(Guid.NewGuid());

        IEnumerable<VitalSigns> vitalSigns = [new VitalSigns(38.8m, 100, 120)];
        c.RegisterVitalSigns(vitalSigns);


        Assert.True(c.VitalSignsReadings.Count == 1);
        Assert.True(c.VitalSignsReadings.First() == vitalSigns.First());
    }
}